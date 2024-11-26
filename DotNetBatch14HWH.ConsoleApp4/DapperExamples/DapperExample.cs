using Dapper;
using DotNetBatch14HWH.ConsoleApp4.BlogDtos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp4.DapperExamples
{
    internal class DapperExample
    {
        public readonly string _connection = AppSettings.sqlConnectionStringBuilder.ConnectionString;

        public void Read()
        {
            DbConnection con = new SqlConnection(_connection);
            con.Open();
            List<BlogDto> lst = con.Query<BlogDto>("select * from tbl_blog").ToList();
            con.Close();

            if (lst.Count > 0)
            {

                foreach (BlogDto blog in lst)
                {
                    Console.WriteLine(blog.BlogId);
                    Console.WriteLine(blog.BlogTitle);
                    Console.WriteLine(blog.BlogContent);
                    Console.WriteLine(blog.BlogAuthor + "\n");
                }
            }
            else
            {
                Console.WriteLine("No record data found");
            }
            Console.ReadLine();
        }

        public void Edit(string id)
        {
            DbConnection con = new SqlConnection(_connection);
            con.Open();
            var item = con.Query<BlogDto>("select * from tbl_blog where blogid = '{id}'").FirstOrDefault();
            con.Close();

            if (item is not null)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }
            else
            {
                Console.WriteLine("No record data found");
            }
            Console.ReadLine();
        }

        public void Create(string title, string author, string content)
        {
            DbConnection con = new SqlConnection(_connection);
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}' 
           ,'{author}'
           ,'{content}'
           )";
            con.Open();
            var result = con.Execute(query);
            con.Close();

            string message = result > 0 ? "create success" : "create fail";
            Console.WriteLine(message);
            Console.ReadLine();

        }

        public void Update(string id,string title, string author, string content)
        {
            DbConnection con = new SqlConnection(_connection);
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = '{title}'
      ,[BlogAuthor] = '{content}'
      ,[BlogContent] = '{author}'
 WHERE [BlogId] = '{id}'";
            con.Open();
            var result = con.Execute(query);
            con.Close();

            string message = result > 0 ? "update success" : "update fail";
            Console.WriteLine(message);
            Console.ReadLine();

        }

        public void Delete(string id)
        {
            DbConnection con = new SqlConnection(_connection);
            string query = $@"DELETE FROM [dbo].[Tbl_Blog] WHERE [BlogId] = '{id}'";
            con.Open();
            var result = con.Execute(query);
            con.Close();

            string message = result > 0 ? "delete success" : "delete fail";
            Console.WriteLine(message);
            Console.ReadLine();

        }
    }
}
