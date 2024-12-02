using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DotNetBatch14HWH.WebApplication2.ConnectionString
{
    public class AppConnectionString
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder() 
        {
            DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
            InitialCatalog = "DotNetBatch14_StudentInfo",
            UserID = "sa",
            Password = "p@ssw0rd",
            TrustServerCertificate = true
        };
    }
}