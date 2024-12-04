using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DotNetBatch14HWH.RestApi3.Features.Blog;

[Route("api/[controller]")]
[ApiController]

public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController()
    {
        _blogService = new EFCoreBlogService();
    }

    [HttpGet]
    public IActionResult GetBlogs()
    {
        var model = _blogService.GetBlogs();
        if (model is null)
            return NotFound("No data Found");
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(string id)
    {
        var model = _blogService.GetBlog(id);
        if (model is null)
            return NotFound("No data Found");
        return Ok(model);
    }

    [HttpPost]
    public IActionResult Post([FromBody] BlogModel requestmodel)
    {
        var model = _blogService.CreateBlog(requestmodel);
        if(!model.IsSuccess)
            return BadRequest(model);
        return Ok(model);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(string id)
    {
        var model = _blogService.DeleteBlog(id);
        if (!model.IsSuccess)
            return BadRequest(model);
        return Ok(model);
    }

    [HttpPatch]
    public IActionResult PatchBlog(string id, BlogModel requestmodel)
    {
        requestmodel.BlogId = id;
        var model = _blogService.PatchBlog(requestmodel);
        if (!model.IsSuccess)
            return BadRequest(model);
        return Ok(model);
    }


    [HttpPut]
    public IActionResult PutBlog(string id, BlogModel requestmodel)
    {
        requestmodel.BlogId = id;
        var model = _blogService.PutBlog(requestmodel);
        if (!model.IsSuccess)
            return BadRequest(model);
        return Ok(model);
    }
}
