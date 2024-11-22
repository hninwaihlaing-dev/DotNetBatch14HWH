using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp2.AdoDotNetExamples;

internal class AdoDotNetExample
{
    SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
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
        SqlCommand command = new SqlCommand("select * from tbl_blog", con);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();

        if(dt.Rows.Count < 1)
        {
            Console.WriteLine("No data found");
            Console.ReadLine();
            return;
        }

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogContent"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine("");
        }
        Console.ReadLine();
    }

    public void Edit(string id) 
    {
        SqlConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        con.Open();
        SqlCommand command = new SqlCommand($"select * from tbl_blog where BlogId = '{id}'", con);
        SqlDataAdapter adapter = new SqlDataAdapter( command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("No data found");
            Console.ReadLine();
            return;
        }

        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogContent"]);
            Console.WriteLine(dr["BlogAuthor"]);
        }
        Console.ReadLine();
    }

    public void Create(string title, string content, string author) 
    {
        SqlConnection con = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        con.Open();
        SqlCommand command = new SqlCommand($@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
           ,'{content}'
           ,'{author}')", con);
        int result = command.ExecuteNonQuery();
        con.Close();

        string message = result > 0 ? "Create Success" : "Create Fail";
        Console.Write(message);
        Console.ReadLine();
    }

    public void Update(string id, string title, string author, string content)
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.Write("No record found");
            Console.ReadLine();
            return;
        }

        SqlConnection con = new SqlConnection( _sqlConnectionStringBuilder.ConnectionString);
        con.Open();
        SqlCommand command = new SqlCommand($@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE [BlogId] = '{id}'", con);
        int result = command.ExecuteNonQuery();
        SqlDataAdapter adapter = new SqlDataAdapter( command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        con.Close();

        string message = result > 0 ? "Update Success" : "Update Fail";
        Console.WriteLine(message);
        
        foreach (DataRow dr in dt.Rows)
        {
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }
        
    }

    public void Delete(string id) 
    {
        if (string.IsNullOrEmpty(id))
        {
            Console.Write("No record found");
            return;
        }
        SqlConnection con = new SqlConnection( _sqlConnectionStringBuilder.ConnectionString);
        con.Open();
        SqlCommand command = new SqlCommand($"delete from tbl_blog where BlogId = '{id}'" , con);
        int result = command.ExecuteNonQuery();
        con.Close();

        string message = result > 0 ? "Delete Success" : "Delete Fail";
        Console.Write(message);
        Console.ReadLine() ;
    }

}
