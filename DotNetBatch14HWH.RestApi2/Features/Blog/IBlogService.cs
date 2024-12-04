
namespace DotNetBatch14HWH.RestApi2.Features.Blog
{
    public interface IBlogService
    {
        BlogResponseModel CreateBlog(BlogModel requestmodel);
        BlogResponseModel DeleteBlog(string id);
        BlogModel GetBlog(string id);
        List<BlogModel> GetBlogs();
        BlogResponseModel PatchBlog(BlogModel requestmodel);
        BlogResponseModel PutBlog(BlogModel requestmodel);
    }
}