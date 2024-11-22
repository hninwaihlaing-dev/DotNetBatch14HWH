//using Microsoft.Data.SqlClient;
//using System;
//using System.Data;

//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
//sqlConnectionStringBuilder.DataSource = "LAPTOP-JLC9N4P3\\SQL2022E";
//sqlConnectionStringBuilder.InitialCatalog = "DotNetBatch14";
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "p@ssw0rd";

//SqlConnection con = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//con.Open();
//Console.WriteLine("connection open successfully");
//SqlCommand cmd = new SqlCommand("select * from student", con);
//SqlDataAdapter adapter = new SqlDataAdapter();
//DataTable dt = new DataTable();
//adapter.Fill(dt);
//con.Close();
//Console.WriteLine("connection close successfully");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("No " + dr["Id"]);
//    Console.WriteLine("Name " + dr["Name"]);
//    Console.WriteLine("Course " + dr["Course"]);
//    Console.WriteLine("Age " + dr["Age"]);
//    Console.WriteLine("Address " + dr["Address"]);
//    Console.WriteLine("<br />");
//}