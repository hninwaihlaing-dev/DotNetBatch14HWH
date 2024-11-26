using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp4.AdoDotNetExamples
{
    internal class AdoDotNetExample
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder
        {
            DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
            InitialCatalog = "DotNetBatch14",
            UserID = "sa",
            Password = "p@ssw0rd",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_blog", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine(dr["BlogId"]);
                    Console.WriteLine(dr["BlogTitle"]);
                    Console.WriteLine(dr["BlogAuthor"]);
                    Console.WriteLine(dr["BlogContent"] + "\n");
                }
            }
            else
            {
                Console.WriteLine("No record found");
            }
            Console.ReadLine();
        }

        public void Edit(string id)
        {
            SqlConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand($@"select * from tbl_blog where blogid = '{id}'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Console.WriteLine(dr["BlogId"]);
                    Console.WriteLine(dr["BlogTitle"]);
                    Console.WriteLine(dr["BlogAuthor"]);
                    Console.WriteLine(dr["BlogContent"] + "\n");
                }
            }
            else
            {
                Console.WriteLine("No record found");
            }
            Console.ReadLine();
        }

        public void Create(string title, string author, string content)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}' 
           ,'{author}'
           ,'{content}'
           )";
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (result == 0)
            {
                Console.WriteLine("create fail");
            }
            else
            {
                Console.WriteLine("create success");
            }
            Console.ReadLine();
        }

        public void Update(string id, string title, string content, string author)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = '{title}'
      ,[BlogAuthor] = '{content}'
      ,[BlogContent] = '{author}'
 WHERE [BlogId] = '{id}'";
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (result == 0)
            {
                Console.WriteLine("update fail");
            }
            else
            {
                Console.WriteLine("update success");
            }
            Console.ReadLine();
        }

        public void Delete(string id)
        {
            string query = $@"DELETE FROM [dbo].[Tbl_Blog] WHERE [BlogId] = '{id}'";
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            if (result == 0)
            {
                Console.WriteLine("delete fail");
            }
            else
            {
                Console.WriteLine("delete success");
            }
            Console.ReadLine();
        }
    }
}
