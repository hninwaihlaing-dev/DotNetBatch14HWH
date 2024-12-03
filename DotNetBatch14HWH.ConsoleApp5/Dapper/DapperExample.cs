using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DotNetBatch14HWH.ConsoleApp5.Dapper;

public class DapperExample
{
    public void Read()
    {
        using DbConnection _dbcon = new SqlConnection(AppConnectionString._sqlConnectionStringBuilder.ConnectionString);

        List<BlogDto> lst = _dbcon.Query<BlogDto>("select * from tbl_blog").ToList();

        if (lst.Count == 0)
        {
            Console.WriteLine("No data found");
            return;
        }
        else if (lst.Count > 0)
        {
            foreach (BlogDto b in lst)
            {
                Console.WriteLine(b.BlogId);
                Console.WriteLine(b.BlogAuthor);
                Console.WriteLine(b.BlogTitle);
                Console.WriteLine(b.BlogContent + "\n");
            }
        }
    }

    public void Edit(string id)
    {
        string query = $"select * from tbl_blog  WHERE BlogId = '{id}'";
        using DbConnection _dbcon = new SqlConnection(AppConnectionString._sqlConnectionStringBuilder.ConnectionString);
        
        var item = _dbcon.Query<BlogDto>(query).FirstOrDefault();
        

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

        using DbConnection _dbcon = new SqlConnection(AppConnectionString._sqlConnectionStringBuilder.ConnectionString);

        int result = _dbcon.Execute(query);
        string message = result > 0 ? "Create success" : "Create fail";
        Console.WriteLine(message);
    }

    public void Update(string id, string title, string author, string content)
    {
        string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE [BlogId] = '{id}'";

        using DbConnection _dbcon = new SqlConnection(AppConnectionString._sqlConnectionStringBuilder.ConnectionString);

        int result = _dbcon.Execute(query);
        string message = result > 0 ? "Update success" : "Update fail";
        Console.WriteLine(message);
    }

    public void Delete(string id)
    {
        string query = $@"delete from tbl_blog where blogid = '{id}'";
        using DbConnection _dbcon = new SqlConnection(AppConnectionString._sqlConnectionStringBuilder.ConnectionString);

        int result = _dbcon.Execute(query);
        string message = result > 0 ? "delete success" : "delete fail";
        Console.WriteLine(message);

    }

}
