using Microsoft.Data.SqlClient;
using System;
using System.Data;

SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
connectionStringBuilder.DataSource = "LAPTOP-JLC9N4P3\\SQL2022E";//servername
connectionStringBuilder.InitialCatalog = "DotNetBatch14"; // database name
connectionStringBuilder.UserID = "sa";
connectionStringBuilder.Password = "p@ssw0rd";
connectionStringBuilder.TrustServerCertificate = true;

SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);
connection.Open();
string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);    
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);
connection.Close();

//Data Table
//Data Row
//Data Columns

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}
Console.ReadLine();


// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Console.WriteLine("Enter User Name");
//string UserName = Console.ReadLine();

//Console.WriteLine("Hello " +  UserName); //one ways
//Console.WriteLine($"Hello {UserName}"); //two ways
//Console.ReadLine();

//Blog

//Id
//Title
//Author
//Content



//calculator
//Calculator calculator = new Calculator();
//calculator.Calculation();

