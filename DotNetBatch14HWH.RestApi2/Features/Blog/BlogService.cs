using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DotNetBatch14HWH.RestApi2.Features.Blog
{
    public class BlogService : IBlogService
    {
        public readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;

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

            List<BlogModel> lst = new List<BlogModel>();
            if (dt.Rows.Count > 0)
            {
                BlogModel model = new BlogModel();
                foreach (DataRow row in dt.Rows)
                {
                    model.BlogId = row["BlogId"].ToString();
                    model.BlogTitle = row["BlogTitle"].ToString();
                    model.BlogAuthor = row["BlogTitle"].ToString();
                    model.BlogContent = row["BlogContent"].ToString();

                    lst.Add(model);
                }
            }
            return lst;
        }

        public BlogModel GetBlog(string id)
        {
            string query = "select * from tbl_blog with (nolock) where BlogId = @bid";

            SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@bid", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            con.Close();

            BlogModel model = new BlogModel();

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];

            model.BlogId = row["BlogId"].ToString();
            model.BlogTitle = row["BlogTitle"].ToString();
            model.BlogAuthor = row["BlogTitle"].ToString();
            model.BlogContent = row["BlogContent"].ToString();

            return model;
        }

        public BlogResponseModel CreateBlog(BlogModel requestmodel)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@Btitle
           ,@Bauthor
           ,@Bcontent)";

            SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Btitle", requestmodel.BlogTitle);
            cmd.Parameters.AddWithValue("@Bauthor", requestmodel.BlogAuthor);
            cmd.Parameters.AddWithValue("@BContent", requestmodel.BlogContent);

            int result = cmd.ExecuteNonQuery();

            con.Close();

            BlogResponseModel model = new BlogResponseModel();

            string message = result > 0 ? "Create success" : "Create fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseModel PatchBlog(BlogModel requestmodel)
        {
            var item = GetBlog(requestmodel.BlogId);

            if (item is null)
            {
                new BlogResponseModel()
                {
                    IsSuccess = false,
                    Message = "No Data found."
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
   SET [BlogTitle] = @Btitle
      ,[BlogAuthor] = @Bauthor
      ,[BlogContent] = @BContent
 WHERE BlogId = @Bid";

            SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Bid", requestmodel.BlogId);
            cmd.Parameters.AddWithValue("@Btitle", requestmodel.BlogTitle);
            cmd.Parameters.AddWithValue("@Bauthor", requestmodel.BlogAuthor);
            cmd.Parameters.AddWithValue("@BContent", requestmodel.BlogContent);

            int result = cmd.ExecuteNonQuery();

            con.Close();

            BlogResponseModel model = new BlogResponseModel();

            string message = result > 0 ? "Update success" : "Update fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public BlogResponseModel PutBlog(BlogModel requestmodel)
        {
            BlogResponseModel model = new BlogResponseModel();

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
   SET [BlogTitle] = @Btitle
      ,[BlogAuthor] = @Bauthor
      ,[BlogContent] = @BContent
 WHERE BlogId = @Bid";

                SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Bid", requestmodel.BlogId);
                cmd.Parameters.AddWithValue("@Btitle", requestmodel.BlogTitle);
                cmd.Parameters.AddWithValue("@Bauthor", requestmodel.BlogAuthor);
                cmd.Parameters.AddWithValue("@BContent", requestmodel.BlogContent);

                int result = cmd.ExecuteNonQuery();

                con.Close();

                string message = result > 0 ? "Update success" : "Update fail";
                model.IsSuccess = result > 0;
                model.Message = message;
            }
            else if (item is null)
            {
                model = CreateBlog(requestmodel);
            }

            return model;
        }

        public BlogResponseModel DeleteBlog(string id)
        {
            string query = "delete from tbl_blog where BlogId = @Bid";

            SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Bid", id);

            int result = cmd.ExecuteNonQuery();

            con.Close();

            BlogResponseModel model = new BlogResponseModel();

            string message = result > 0 ? "Delete success" : "Delete fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

    }
}

