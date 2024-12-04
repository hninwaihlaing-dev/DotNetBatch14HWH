
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DotNetBatch14HWH.RestApi3.Features.Blog
{
    public class EFCoreBlogService : IBlogService
    {
        public AppDbContext apc;
        public EFCoreBlogService()
        {
            apc = new AppDbContext();
        }

        public ResponseBlogModel CreateBlog(BlogModel requestmodel)
        {
            requestmodel.BlogId = Guid.NewGuid().ToString();
            apc.blogs.Add(requestmodel);
            int result = apc.SaveChanges();

            ResponseBlogModel model = new ResponseBlogModel();
            string message = result > 0 ? "Create success" : "Create fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public ResponseBlogModel DeleteBlog(string id)
        {
            var item = apc.blogs.AsNoTracking().Where(x => x.BlogId == id).FirstOrDefault();
            apc.Entry(item).State = EntityState.Deleted;
            int result = apc.SaveChanges();

            ResponseBlogModel model = new ResponseBlogModel();
            string message = result > 0 ? "Delete success" : "Delete fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogModel GetBlog(string id)
        {
            var item = apc.blogs.AsNoTracking().Where(x => x.BlogId == id).FirstOrDefault();
            if (item is null) return null;
            return item!;
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = apc.blogs.ToList();
            return lst;
        }

        public ResponseBlogModel PatchBlog(BlogModel requestmodel)
        {
            var item = apc.blogs.AsNoTracking().Where(x => x.BlogId == requestmodel.BlogId).FirstOrDefault();
            if (item is null)
            {
                return new ResponseBlogModel()
                {
                    IsSuccess = false,
                    Message = "No data found"
                };
            }
            if (string.IsNullOrEmpty(requestmodel.BlogTitle))
            {
                requestmodel.BlogTitle = item.BlogTitle;
            }
            if (string.IsNullOrEmpty(requestmodel.BlogAuthor))
            {
                requestmodel.BlogAuthor = item.BlogAuthor;
            }
            if (string.IsNullOrEmpty(requestmodel.BlogContent))
            {
                requestmodel.BlogContent = item.BlogContent;
            }

            apc.Entry(item).State = EntityState.Modified;
            int result = apc.SaveChanges();

            ResponseBlogModel model = new ResponseBlogModel();
            string message = result > 0 ? "Update success" : "Update fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public ResponseBlogModel PutBlog(BlogModel requestmodel)
        {
            ResponseBlogModel model = new ResponseBlogModel();

            var item = apc.blogs.AsNoTracking().Where(x => x.BlogId == requestmodel.BlogId).FirstOrDefault();
            if (item is not null)
            {

                if (string.IsNullOrEmpty(requestmodel.BlogTitle))
                {
                    requestmodel.BlogTitle = item.BlogTitle;
                }
                if (string.IsNullOrEmpty(requestmodel.BlogAuthor))
                {
                    requestmodel.BlogAuthor = item.BlogAuthor;
                }
                if (string.IsNullOrEmpty(requestmodel.BlogContent))
                {
                    requestmodel.BlogContent = item.BlogContent;
                }

                apc.Entry(item).State = EntityState.Modified;
                int result = apc.SaveChanges();

                string message = result > 0 ? "Update success" : "Update fail";
                model.IsSuccess = result > 0;
                model.Message = message;
            }
            else if(item is null)
            {
                model = CreateBlog(requestmodel);
            }

            return model;
        }
    }
}
