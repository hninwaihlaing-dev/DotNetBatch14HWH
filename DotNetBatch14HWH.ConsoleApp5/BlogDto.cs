using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp5
{
    [Table("tbl_blog")]
    public class BlogDto
    {
        [Key]
        [Column("BlogId")]
        public string BlogId { get; set; }
        [Column("BlogTitle")]
        public string BlogTitle { get; set; }
        [Column("BlogAuthor")]
        public string BlogAuthor { get; set; }
        [Column("BlogContent")]
        public string BlogContent { get; set; }
    }
}
