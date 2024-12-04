using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace DotNetBatch14HWH.RestApi2.Features.Blog;

[Route("api/[controller]")]
[ApiController]

public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController()
    {
        _blogService = new DapperService();
    }

    [HttpGet]
    public IActionResult GetBlogs()
    {
        var model = _blogService.GetBlogs();
        if (model is null)
        {
            return NotFound("No record found");
        }
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(string id)
    {
        var model = _blogService.GetBlog(id);
        if (model is null)
        {
            return NotFound("No record found");
        }
        return Ok(model);
    }

    [HttpPost]
    public IActionResult PostBlog([FromBody] BlogModel blogmodel)
    {
        var model = _blogService.CreateBlog(blogmodel);
        if (!model.IsSuccess)
        {
            return BadRequest(model);
        }
        return Ok(model);
    }

    [HttpPatch]
    public IActionResult PatchBlog(string id, BlogModel blogmodel) 
    {
        blogmodel.BlogId = id;
        var model = _blogService.PatchBlog(blogmodel);

        if (!model.IsSuccess) 
        { 
            return BadRequest(model);
        }
        return Ok(model);
    }
    [HttpPut]
    public IActionResult PutBlog(string id, BlogModel blogmodel)
    {
        blogmodel.BlogId = id;
        var model = _blogService.PutBlog(blogmodel);
        if (!model.IsSuccess)
        {
            return BadRequest(model);
        }
        return Ok(model);
    }

    [HttpDelete]
    public IActionResult DeleteBlog(string id)
    {
        var model = _blogService.DeleteBlog(id);

        if (!model.IsSuccess)
        {
            return BadRequest(model);
        }
        return Ok(model);
    }
}
