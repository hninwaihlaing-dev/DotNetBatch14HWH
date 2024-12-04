using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DotNetBatch14HWH.RestApi3.Features.Blog
{
    public class BlogService : IBlogService
    {
        public readonly SqlConnectionStringBuilder _sqlconnectionStringBuilder;

        public BlogService()
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
            SqlConnection con = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);
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
            string query = "select * from tbl_blog with (nolock) where blogid = @bid";
            SqlConnection con = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@bid", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            con.Close();

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            BlogModel model = new BlogModel();
            DataRow dr = dt.Rows[0];

            model.BlogId = dr["BlogId"].ToString()!;
            model.BlogAuthor = dr["BlogAuthor"].ToString()!;
            model.BlogTitle = dr["BlogTitle"].ToString()!;
            model.BlogContent = dr["BlogContent"].ToString()!;


            return model;
        }

        public ResponseBlogModel CreateBlog(BlogModel requestmodel)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@Btitle
           ,@Bauthor
           ,@Bcontent)";
            SqlConnection con = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Btitle", requestmodel.BlogTitle);
            cmd.Parameters.AddWithValue("@Bauthor", requestmodel.BlogAuthor);
            cmd.Parameters.AddWithValue("@Bcontent", requestmodel.BlogContent);

            int result = cmd.ExecuteNonQuery();

            con.Close();

            ResponseBlogModel model = new ResponseBlogModel();
            string message = result > 0 ? "Create success" : "Create fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public ResponseBlogModel DeleteBlog(string id)
        {
            string query = $@"delete from tbl_blog where BlogId = @Id";
            SqlConnection con = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", id);

            int result = cmd.ExecuteNonQuery();

            con.Close();

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
   SET [BlogTitle] = @Btitle
      ,[BlogAuthor] = @Bauthor
      ,[BlogContent] = @Bcontent
 WHERE BlogId = @BId";
            SqlConnection con = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);
            con.Open();

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BId", requestmodel.BlogId);
            cmd.Parameters.AddWithValue("@Btitle", requestmodel.BlogTitle);
            cmd.Parameters.AddWithValue("@Bauthor", requestmodel.BlogAuthor);
            cmd.Parameters.AddWithValue("@Bcontent", requestmodel.BlogContent);

            int result = cmd.ExecuteNonQuery();

            con.Close();

            ResponseBlogModel model = new ResponseBlogModel();
            string message = result > 0 ? "Update success" : "Update fail";
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
   SET [BlogTitle] = @Btitle
      ,[BlogAuthor] = @Bauthor
      ,[BlogContent] = @Bcontent
 WHERE BlogId = @BId";
                SqlConnection con = new SqlConnection(_sqlconnectionStringBuilder.ConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BId", requestmodel.BlogId);
                cmd.Parameters.AddWithValue("@Btitle", requestmodel.BlogTitle);
                cmd.Parameters.AddWithValue("@Bauthor", requestmodel.BlogAuthor);
                cmd.Parameters.AddWithValue("@Bcontent", requestmodel.BlogContent);

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
    }
}
