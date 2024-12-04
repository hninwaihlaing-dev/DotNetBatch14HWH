using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBatch14HWH.RestApi3.Features.Blog
{
    [Table("tbl_blog")]
    public class BlogModel
    {
        [Key]
        public string? BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }

    }

    public class ResponseBlogModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}

