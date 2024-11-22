using Dapper;
using DotNetBatch14HWH.ConsoleApp2.AdoDotNetExamples;
using DotNetBatch14HWH.ConsoleApp2.Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp2.DapperExamples;

internal class DapperExample
{
    private readonly string _connectionString = AppSettings.SqlConnectionStringBuilder.ConnectionString;

    public void Read()
    {
        using DbConnection connection = new SqlConnection(_connectionString);
        List<BlogDto> lst = connection.Query<BlogDto>("select * from tbl_blog").ToList();

        foreach (var item in lst)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("");
        }
        Console.ReadLine();
    }

    public void Edit(string id)
    {
        using DbConnection connection = new SqlConnection(AppSettings.SqlConnectionStringBuilder.ConnectionString);
        var item = connection.Query<BlogDto>($"select * from tbl_blog where blogid = '{id}'").FirstOrDefault();


        if (item is null)
        {
            Console.WriteLine("No data found");
            Console.ReadLine();
        }
        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
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
           ,'{content}'
           ,'{author}')";
        using DbConnection connection = new SqlConnection(AppSettings.SqlConnectionStringBuilder.ConnectionString);
        var result = connection.Execute(query);

        string message = result > 0 ? "create success" : "create faile";
        Console.WriteLine(message);

    }
    
    public void Update(string id,string title, string author, string content)
    {
        string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE [BlogId] = '{id}'";
        using DbConnection connection = new SqlConnection(AppSettings.SqlConnectionStringBuilder.ConnectionString);
        var result = connection.Execute(query);

        string message = result > 0 ? "update success" : "update fail";
        Console.WriteLine(message);
    }

    public void Delete(string id) 
    {
        string query = $"delete from tbl_blog where BlogId = '{id}'";
        using DbConnection connection = new SqlConnection(AppSettings.SqlConnectionStringBuilder.ConnectionString);
        connection.Execute(query);

        var result = connection.Execute(query);

        string message = result > 0 ? "delete success" : "delete fail";
        Console.WriteLine(message);
    }

} 

