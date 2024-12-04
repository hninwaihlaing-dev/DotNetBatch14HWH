using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using Dapper;

namespace DotNetBatch14HWH.RestApi4.Features.Blog
{
    public class DapperBlogService : IBlogService
    {

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public DapperBlogService()
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
                InitialCatalog = "DotNetBatch14",
                UserID = "sa",
                Password = "p@ssw0rd",
                TrustServerCertificate = true
            };
        }

        public BlogResponseMode CreateBlog(BlogModel requestModel)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            using DbConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = con.Execute(query, requestModel);

            BlogResponseMode model = new BlogResponseMode();
            string message = result > 0 ? "Create success" : "Create Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseMode DeleteBlog(string id)
        {
            string query = $@"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            using DbConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = con.Execute(query, new BlogModel()
            {
                BlogId = id
            });

            BlogResponseMode model = new BlogResponseMode();
            string message = result > 0 ? "Delete success" : "Delete Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogModel GetBlog(string id)
        {
            string query = "SELECT * FROM tbl_blog WITH (NOLOCK) WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            var item = db.QueryFirstOrDefault<BlogModel>(query, new { BlogId = id });
            return item!;
        }

        public List<BlogModel> GetBlogs()
        {
            string query = "select * from tbl_blog with (nolock)";
            using DbConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            var lst = con.Query<BlogModel>(query).ToList();
            return lst;
        }

        public BlogResponseMode UpdateBlog(BlogModel requestModel)
        {
            var item = GetBlog(requestModel.BlogId);
            if (item is null)
            {
                return new BlogResponseMode()
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

            using DbConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = con.Execute(query, requestModel);

            BlogResponseMode model = new BlogResponseMode();
            string message = result > 0 ? "Update success" : "Update Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseMode UpSertBlog(BlogModel requestModel)
        {
            BlogResponseMode model = new BlogResponseMode();
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

                using DbConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
                int result = con.Execute(query, requestModel);

                string message = result > 0 ? "Update success" : "Update Fail";
                model.IsSuccess = result > 0;
                model.Message = message;
            }
            else if (item is null)
            {
                model = CreateBlog(requestModel);
            }

            return model;
        }
    }
}
