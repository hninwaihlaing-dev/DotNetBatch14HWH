using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14HWH.Shared;

public class AppDbCotext : DbContext
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public AppDbCotext()
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
            InitialCatalog = "DotNetBatch14",
            UserID = "sa",
            Password = "p@ssw0rd",
            TrustServerCertificate = true
        };
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }
    public DbSet<BlogModel> Blogs { get; set; }
}
