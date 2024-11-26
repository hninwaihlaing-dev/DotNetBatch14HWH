using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp3.EFCoreExamples
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.sqlConnectionStringBuilder.ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<TblBlog> Blogs { get; set; }
    }

    [Table("tbl_blog")]

    public class TblBlog
    {
        [Key]
        [Column("BlogId")]
        public string Id { get; set; }

        [Column("BlogTitle")]
        public string Title { get; set; }

        [Column("BlogAuthor")]
        public string Author { get; set; }

        [Column("BlogContent")]
        public string Content { get; set; }
    }
}
