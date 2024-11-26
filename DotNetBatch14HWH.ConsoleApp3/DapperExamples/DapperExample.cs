using Dapper;
using DotNetBatch14HWH.ConsoleApp3.BlogDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp3.DapperExamples;

internal class DapperExample
{
    public readonly string _connection = AppSettings.sqlConnectionStringBuilder.ConnectionString;

    public void Read()
    {
        using DbConnection dbConnection = new SqlConnection( _connection );
        List<BlogDto> blogs = dbConnection.Query<BlogDto>("select * from tbl_blog").ToList();
        
        if( blogs.Count == 0)
        {
            Console.WriteLine("No record found");
            Console.ReadLine();
            return;
        }

        foreach(BlogDto blog in blogs)
        {
            Console.WriteLine(blog.BlogId);
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);
            Console.WriteLine("");
        }
        Console.ReadLine();
    }

    public void Edit(string id)
    {
        using DbConnection con = new SqlConnection( _connection );  

        var item = con.Query<BlogDto>($"select * from tbl_blog where blogid = '{id}'").FirstOrDefault();

        if(item != null)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("No record found");
        }
        Console.ReadLine();
    }

    public void Create(string title, string author, string content)
    {
        using DbConnection con = new SqlConnection(_connection);

        string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}' 
           ,'{author}'
           ,'{content}'
           )";

        var result = con.Execute(query);
        string message = result > 0 ? "create success" : "create fail";
        Console.WriteLine(message);
    }

    public void Update(string id, string title, string content, string author)
    {
        string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = '{title}'
      ,[BlogAuthor] = '{content}'
      ,[BlogContent] = '{author}'
 WHERE [BlogId] = '{id}'";
        DbConnection con = new SqlConnection(_connection );
        con.Open();
        int result = con.Execute(query);
        con.Close();

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
        using DbConnection con = new SqlConnection(_connection);

        string query = $@"DELETE FROM [dbo].[Tbl_Blog] WHERE [BlogId] = '{id}'";

        var result = con.Execute(query);
        string message = result > 0 ? "delete success" : "delete fail";
        Console.WriteLine(message);
        Console.ReadLine();
    }
    
}
