using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DotNetBatch14HWH.RestApi3.Features.Blog
{
    public class DapperBlogService : IBlogService
    {
        public readonly SqlConnectionStringBuilder _sqlconnectionStringBuilder;

        public DapperBlogService()
        {
            _sqlconnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
                InitialCatalog = "DotNetBatch14",
                UserID = "sa",
                Password = "p@ssw0rd",
                TrustServerCertificate = true
            };
        }

        public List<BlogModel> GetBlogs()
        {
            string query = "select * from tbl_blog with (nolock)";
            using DbConnection con = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);

            var lst = con.Query<BlogModel>(query).ToList();
            return lst;
        }

        public BlogModel GetBlog(string id)
        {
            string query = "SELECT * FROM tbl_blog WITH (NOLOCK) WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);

            var item = db.QueryFirstOrDefault<BlogModel>(query, new { BlogId = id });
            if (item is null) return null;
            return item!;
        }

        public ResponseBlogModel CreateBlog(BlogModel requestmodel)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            using DbConnection db = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, requestmodel);

            ResponseBlogModel model = new ResponseBlogModel();
            string message = result > 0 ? "Create success" : "Create fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public ResponseBlogModel DeleteBlog(string id)
        {
            string query = $@"delete from tbl_blog where BlogId = @BlogId";
            using DbConnection db = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, new BlogModel()
            {
                BlogId = id
            });

            ResponseBlogModel model = new ResponseBlogModel();
            string message = result > 0 ? "Delete success" : "Delete fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public ResponseBlogModel PatchBlog(BlogModel requestmodel)
        {
            var item = GetBlog(requestmodel.BlogId);
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
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            using DbConnection con = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);
            int result = con.Execute(query, requestmodel);

            ResponseBlogModel model = new ResponseBlogModel();
            string message = result > 0 ? "Update success" : "Update Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public ResponseBlogModel PutBlog(BlogModel requestmodel)
        {
            ResponseBlogModel model = new ResponseBlogModel();
            var item = GetBlog(requestmodel.BlogId);
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
                string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

                using DbConnection con = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);
                int result = con.Execute(query, requestmodel);

                string message = result > 0 ? "Update success" : "Update Fail";
                model.IsSuccess = result > 0;
                model.Message = message;

                return model;
            }
            else if (item is null)
            {
                model = CreateBlog(requestmodel);
            }

            return model;
        }
    }
}
