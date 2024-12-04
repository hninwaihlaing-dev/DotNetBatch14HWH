
namespace DotNetBatch14HWH.RestApi3.Features.Blog
{
    public interface IBlogService
    {
        ResponseBlogModel CreateBlog(BlogModel requestmodel);
        ResponseBlogModel DeleteBlog(string id);
        BlogModel GetBlog(string id);
        List<BlogModel> GetBlogs();
        ResponseBlogModel PatchBlog(BlogModel requestmodel);
        ResponseBlogModel PutBlog(BlogModel requestmodel);
    }
}