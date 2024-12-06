
namespace DotNetBatch14HWH.RestApi5.Features.Blog
{
    public interface IBlogService
    {
        BlogResponseModel CreateBlog(BlogModel requestModel);
        BlogResponseModel DeleteBlog(string id);
        BlogModel GetBlog(string id);
        List<BlogModel> GetBlogs();
        BlogResponseModel UpdateBlog(BlogModel requestModel);
        BlogResponseModel UpSertBlog(BlogModel requestModel);
    }
}