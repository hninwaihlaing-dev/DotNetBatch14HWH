using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp3;

internal class AppSettings
{
    public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
        InitialCatalog = "DotNetBatch14",
        UserID = "sa",
        Password = "p@ssw0rd",
        TrustServerCertificate = true
    };
}
