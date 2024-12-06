using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14HWH.RestApi5.Features.Blog
{
    public class BlogEFCoreService : IBlogService
    {
        private readonly AppDbContext _db;
        public BlogEFCoreService()
        {
            _db = new AppDbContext();
        }

        #region
        public List<BlogModel> GetBlogs()
        {

            var lst = _db.Blogs.ToList();
            return lst;
        }
        #endregion

        #region
        public BlogModel GetBlog(string id)
        {
            var item = _db.Blogs.AsNoTracking().Where(x => x.BlogId == id).FirstOrDefault();
            if (item is null) return null;
            return item;
        }
        #endregion

        #region
        public BlogResponseModel CreateBlog(BlogModel requestModel)
        {
            requestModel.BlogId = Guid.NewGuid().ToString();
            _db.Blogs.Add(requestModel);
            int result = _db.SaveChanges();

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Create Success" : "Create Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
        #endregion

        #region
        public BlogResponseModel DeleteBlog(string id)
        {
            var item = _db.Blogs.AsNoTracking().Where(x => x.BlogId == id).FirstOrDefault();
            _db.Entry(item).State = EntityState.Deleted;
            int result = _db.SaveChanges();

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Delete Success" : "Delete Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
        #endregion

        #region
        public BlogResponseModel UpdateBlog(BlogModel requestModel)
        {
            var item = GetBlog(requestModel.BlogId);
            if (item is null)
            {
                return new BlogResponseModel()
                {
                    IsSuccess = false,
                    Message = "No Data found."
                };
            }
            if (string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                requestModel.BlogTitle = item.BlogTitle;
            }
            if (string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                requestModel.BlogAuthor = item.BlogAuthor;
            }
            if (string.IsNullOrEmpty(requestModel.BlogContent))
            {
                requestModel.BlogContent = item.BlogContent;
            }

            _db.Entry(item).State = EntityState.Modified;
            int result = _db.SaveChanges();

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Update Success" : "Update Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
        #endregion

        #region
        public BlogResponseModel UpSertBlog(BlogModel requestModel)
        {
            BlogResponseModel model = new BlogResponseModel();
            var item = GetBlog(requestModel.BlogId);
            if (item is null)
            {
                model = CreateBlog(requestModel);
            }
            if (item is not null)
            {
                if (string.IsNullOrEmpty(requestModel.BlogTitle))
                {
                    requestModel.BlogTitle = item.BlogTitle;
                }
                if (string.IsNullOrEmpty(requestModel.BlogAuthor))
                {
                    requestModel.BlogAuthor = item.BlogAuthor;
                }
                if (string.IsNullOrEmpty(requestModel.BlogContent))
                {
                    requestModel.BlogContent = item.BlogContent;
                }

                _db.Entry(item).State = EntityState.Modified;
                int result = _db.SaveChanges();

                string message = result > 0 ? "Update Success" : "Update Fail";
                model.IsSuccess = result > 0;
                model.Message = message;
            }
            return model;
        }
        #endregion
    }
}


