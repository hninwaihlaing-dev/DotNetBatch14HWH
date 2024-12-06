using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace DotNetBatch14HWH.RestApi5.Features.Blog
{
    public class BlogDapperService : IBlogService
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder;
        public BlogDapperService()
        {
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
                InitialCatalog = "DotNetBatch14",
                UserID = "sa",
                Password = "p@ssw0rd",
                TrustServerCertificate = true
            };
        }

        public BlogResponseModel CreateBlog(BlogModel requestModel)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, requestModel);

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Create Success" : "Create Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;

        }

        public BlogResponseModel DeleteBlog(string id)
        {
            string query = $@"delete from tbl_blog where BlogId = @BlogId";

            using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, new BlogModel()
            {
                BlogId = id
            });

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Delete Success" : "Delete Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogModel GetBlog(string id)
        {
            string query = "select * from tbl_blog with (nolock) where BlogId = @BlogId";
            using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new {BlogId= id }).FirstOrDefault();

            if (item is null) return null;
            return item;
        }

        public List<BlogModel> GetBlogs()
        {
            string query = "select * from tbl_blog with (nolock)";
            using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var lst = db.Query<BlogModel>(query).ToList();

            return lst;
        }

        public BlogResponseModel UpdateBlog(BlogModel requestModel)
        {
            var item = GetBlog(requestModel.BlogId);
            if (item is null)
            {
                return new BlogResponseModel()
                {
                    IsSuccess = false,
                    Message = "No data found"
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

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, requestModel);

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Update Success" : "Update Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseModel UpSertBlog(BlogModel requestModel)
        {
            BlogResponseModel model = new BlogResponseModel();
            var item = GetBlog(requestModel.BlogId);
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

                string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
                using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                int result = db.Execute(query, requestModel);

                string message = result > 0 ? "Update Success" : "Update Fail";
                model.IsSuccess = result > 0;
                model.Message = message;
            }
            else if(item is null)
            {
                model = CreateBlog(requestModel);   
            }
            return model;
        }
    }
}
