using DotNetBatch14HWH.RestApi5.Features.Transfer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14HWH.RestApi5.Features.MiniPOS
{
    public class AppDbContext : DbContext
    {
        public readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;

        public AppDbContext()
        {
            sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "LAPTOP-JLC9N4P3\\SQL2022E",
                InitialCatalog = "DotNetBatch14_MiniPOS",
                UserID = "sa",
                Password = "p@ssw0rd",
                TrustServerCertificate = true
            };
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<SaleModel> Sales { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}
