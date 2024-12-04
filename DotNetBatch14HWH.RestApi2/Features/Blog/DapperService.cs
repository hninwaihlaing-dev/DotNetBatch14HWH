
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DotNetBatch14HWH.RestApi2.Features.Blog
{
    public class DapperService : IBlogService
    {
        public readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;

        public DapperService()
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
        public BlogResponseModel CreateBlog(BlogModel requestmodel)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
           @BlogAuthor,
           @BlogContent
           )";

            using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, requestmodel);

            BlogResponseModel model = new BlogResponseModel();

            string message = result > 0 ? "Create success" : "Create fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseModel DeleteBlog(string id)
        {
            string query = $@"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, new BlogModel()
            {
                BlogId = id
            });

            BlogResponseModel model = new BlogResponseModel();

            string message = result > 0 ? "Delete success" : "Delete fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogModel GetBlog(string id)
        {
            BlogModel blogModel = new BlogModel();
            blogModel.BlogId = id;
            string query = "select * from tbl_blog with (nolock) where BlogId = @BlogId";
            using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var item = db.QueryFirstOrDefault(query, new BlogModel { BlogId = id});

            if (item is null)
            { 
                return null;
            }
            blogModel.BlogId = item.BlogId;
            blogModel.BlogAuthor = item.BlogAuthor;
            blogModel.BlogTitle = item.BlogTitle;
            blogModel.BlogContent = item.BlogContent;

            return blogModel;

        }

        public List<BlogModel> GetBlogs()
        {
            string query = "select * from tbl_blog with (nolock)";
            using DbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
            return lst;
        }

        public BlogResponseModel PatchBlog(BlogModel requestmodel)
        {
            var item = GetBlog(requestmodel.BlogId);

            BlogResponseModel model = new BlogResponseModel();
            if (item is null)
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
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            using DbConnection _db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            int result = _db.Execute(query, requestmodel);
            string message = result > 0 ? "Update success" : "Update fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseModel PutBlog(BlogModel requestmodel)
        {
            var item = GetBlog(requestmodel.BlogId);

            BlogResponseModel model = new BlogResponseModel();
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

                using DbConnection _db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

                int result = _db.Execute(query, requestmodel);
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
