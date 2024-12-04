using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetBatch14HWH.RestApi4.Features.Blog
{

    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public string? BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }

    public class BlogResponseMode
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
