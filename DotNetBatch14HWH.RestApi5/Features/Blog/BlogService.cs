using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBatch14HWH.RestApi5.Features.Blog
{
    public class BlogService : IBlogService
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder;
        public BlogService()
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

        public List<BlogModel> GetBlogs()
        {
            string query = "select * from tbl_blog with (nolock)";
            SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            con.Close();

            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel()
            {
                BlogId = dr["BlogId"].ToString(),
                BlogAuthor = dr["BlogAuthor"].ToString(),
                BlogTitle = dr["BlogTitle"].ToString(),
                BlogContent = dr["BlogContent"].ToString()

            }).ToList();

            return lst;
        }

        public BlogModel GetBlog(string id)
        {
            string query = "select * from tbl_blog with (nolock) where BlogId = @Id";
            SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("Id", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            con.Close();

            if (dt.Rows.Count == 0) return null;

            BlogModel model = new BlogModel();
            DataRow dr = dt.Rows[0];

            model.BlogId = dr["BlogId"].ToString();
            model.BlogAuthor = dr["BlogAuthor"].ToString();
            model.BlogTitle = dr["BlogTitle"].ToString();
            model.BlogContent = dr["BlogContent"].ToString();

            return model;
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
            SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("BlogTitle", requestModel.BlogTitle);
            cmd.Parameters.AddWithValue("BlogAuthor", requestModel.BlogAuthor);
            cmd.Parameters.AddWithValue("BlogContent", requestModel.BlogContent);
            int result = cmd.ExecuteNonQuery();

            con.Close();

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Create Success" : "Create Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
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
            SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("BlogId", requestModel.BlogId);
            cmd.Parameters.AddWithValue("BlogTitle", requestModel.BlogTitle);
            cmd.Parameters.AddWithValue("BlogAuthor", requestModel.BlogAuthor);
            cmd.Parameters.AddWithValue("BlogContent", requestModel.BlogContent);
            int result = cmd.ExecuteNonQuery();

            con.Close();

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
                SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("BlogId", requestModel.BlogId);
                cmd.Parameters.AddWithValue("BlogTitle", requestModel.BlogTitle);
                cmd.Parameters.AddWithValue("BlogAuthor", requestModel.BlogAuthor);
                cmd.Parameters.AddWithValue("BlogContent", requestModel.BlogContent);
                int result = cmd.ExecuteNonQuery();

                con.Close();

                string message = result > 0 ? "Update Success" : "Update Fail";
                model.IsSuccess = result > 0;
                model.Message = message;
            }
            else if (item is null)
            {
                model = CreateBlog(requestModel);
            }
            return model;
        }

        public BlogResponseModel DeleteBlog(string id)
        {
            string query = $@"delete from tbl_blog where BlogId = @BlogId";
            SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("BlogId", id);
            int result = cmd.ExecuteNonQuery();

            con.Close();

            BlogResponseModel model = new BlogResponseModel();
            string message = result > 0 ? "Delete Success" : "Delete Fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public static implicit operator BlogService(BlogDapperService v)
        {
            throw new NotImplementedException();
        }
    }
}
