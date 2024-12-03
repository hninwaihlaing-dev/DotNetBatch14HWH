using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp5.AdoDotNet;

public class AdoDotNetExample
{
    SqlConnection con = new SqlConnection(AppConnectionString._sqlConnectionStringBuilder.ConnectionString);

    public void Read()
    {
        string query = "select * from tbl_blog(nolock)";

        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        con.Close();

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["BlogId"]);
                Console.WriteLine(row["BlogTitle"]);
                Console.WriteLine(row["BlogAuthor"]);
                Console.WriteLine(row["BlogContent"] + "\n");
            }
        }
        else if (dt.Rows.Count == 0)
        {
            Console.WriteLine("No data found");
        }
    }

    public void Edit(string id)
    {
        string query = "select * from tbl_blog(nolock) where BlogId = @Bid";

        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Bid", id);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        con.Close();

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("No data found");
        }

        DataRow row = dt.Rows[0];
        Console.WriteLine(row["BlogId"]);
        Console.WriteLine(row["BlogTitle"]);
        Console.WriteLine(row["BlogAuthor"]);
        Console.WriteLine(row["BlogContent"] + "\n");

    }

    public void Create(string title, string author, string content)
    {
        string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@Btitle
           ,@Bauthor
           ,@Bcontent
           )";

        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Btitle", title);
        cmd.Parameters.AddWithValue("@Bauthor", author);
        cmd.Parameters.AddWithValue("@Bcontent", content);

        int result = cmd.ExecuteNonQuery();

        con.Close();

        string message = result > 0 ? "Create success" : "Create fail";
        Console.WriteLine(message);
    }

    public void Delete(string id)
    {
        string query = "delete from tbl_blog where BlogId = @Bid";

        con.Open();

        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Bid", id);
        int result = cmd.ExecuteNonQuery();

        con.Close();

        string message = result > 0 ? "Delete success" : "Delete fail";
        Console.WriteLine(message);
    }

    public void Update(string id, string title, string author, string content)
    {
        string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @Btitle
      ,[BlogAuthor] = @Bauthor
      ,[BlogContent] = @Bcontent
 WHERE [BlogId] = @Bid";

        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@Bid", id);
        cmd.Parameters.AddWithValue("@Btitle", title);
        cmd.Parameters.AddWithValue("@Bauthor", author);
        cmd.Parameters.AddWithValue("@Bcontent", content);

        int result = cmd.ExecuteNonQuery();

        con.Close();

        string message = result > 0 ? "Update success" : "Update fail";
        Console.WriteLine(message);
    }
}
