using DotNetBatch14HWH.ConsoleApp6HttpClient;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient;

internal class BlogRefitClientService
{
    private readonly string endpoint = "http://localhost:5146";
    private readonly IBlogApi _api;

    public BlogRefitClientService()
    {
        _api = RestService.For<IBlogApi>(endpoint);
    }

    public async Task<BlogListResponseModel> GetBlogs()
    {
        var model = await _api.GetBlogs();
        return model;
    }

    public async Task<BlogResponseMode> GetBlog(string id)
    {
        var model = await _api.GetBlog(id);
        return model;
    }

    public async Task<BlogResponseMode> CreateBlog(BlogModel RequestModel)
    {
        var model = await _api.CreateBlog(RequestModel);
        return model;
    }

    public async Task<BlogResponseMode> PatchBlog(string id, BlogModel RequestModel)
    {
        var model = await _api.PatchBlog(id, RequestModel);
        return model;
    }
    public async Task<BlogResponseMode> DeleteBlog(string id)
    {
        var model = await _api.DeleteBlog(id);
        return model;
    }
}


// Interface = I
// Features = Blog
// Type = Api
public interface IBlogApi
{
[Get("/api/blog")]
Task<BlogListResponseModel> GetBlogs();

[Get("/api/blog/{id}")]
Task<BlogResponseMode> GetBlog(string id);

[Post("/api/blog")]
Task<BlogResponseMode> CreateBlog(BlogModel RequestModel);

[Patch("/api/blog/{id}")]
Task<BlogResponseMode> PatchBlog(string id, BlogModel RequestModel);

[Delete("/api/blog/{id}")]
Task<BlogResponseMode> DeleteBlog(string id);
}