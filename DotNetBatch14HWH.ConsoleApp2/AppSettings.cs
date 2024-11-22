using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp2;

public static class AppSettings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder { get; } = new SqlConnectionStringBuilder()
    {
        DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
        InitialCatalog = "DotNetBatch14",
        UserID = "sa",
        Password = "p@ssw0rd",
        TrustServerCertificate = true
    };

}