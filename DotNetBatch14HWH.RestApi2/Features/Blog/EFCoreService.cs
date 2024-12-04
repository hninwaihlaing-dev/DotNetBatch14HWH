using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14HWH.RestApi2.Features.Blog
{
    public class EFCoreService : IBlogService
    {
        public readonly ApppDBContext _db;

        public EFCoreService()
        {
            _db = new ApppDBContext();
        }

        public BlogResponseModel CreateBlog(BlogModel requestmodel)
        {
            requestmodel.BlogId = Guid.NewGuid().ToString(); 

            _db.blogs.Add(requestmodel);
            int result = _db.SaveChanges();

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Create success" : "Create fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseModel DeleteBlog(string id)
        {
            var item = _db.blogs.AsNoTracking().Where(x => x.BlogId == id).FirstOrDefault();
            _db.Entry(item).State = EntityState.Deleted;
            int result = _db.SaveChanges();

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Delete success" : "Delete fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogModel GetBlog(string id)
        {
            var item = _db.blogs.AsNoTracking().Where(x => x.BlogId == id).FirstOrDefault();
            return item!;
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = _db.blogs.ToList();
            return lst;
        }

        public BlogResponseModel PatchBlog(BlogModel requestmodel)
        {
            BlogResponseModel model = new BlogResponseModel();
            var item = _db.blogs.AsNoTracking().Where(x => x.BlogId == requestmodel.BlogId).FirstOrDefault();

            if(item is null)
            {
                model.IsSuccess = false;
                model.Message = "No data found";

                return model;
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
            _db.Entry(item).State = EntityState.Modified;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Update success" : "Update fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseModel PutBlog(BlogModel requestmodel)
        {
            BlogResponseModel model = new BlogResponseModel();
            var item = _db.blogs.AsNoTracking().Where(x => x.BlogId == requestmodel.BlogId).FirstOrDefault();

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
                _db.Entry(item).State = EntityState.Modified;
                int result = _db.SaveChanges();

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
