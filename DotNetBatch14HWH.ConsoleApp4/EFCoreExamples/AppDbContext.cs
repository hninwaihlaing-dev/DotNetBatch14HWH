using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp4.EFCoreExamples
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.sqlConnectionStringBuilder.ConnectionString);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<TblBlog> blogs { get; set; }   
    }
    [Table("Tbl_Blog")]

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
