using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14HWH.RestApi5.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public readonly IBlogService _blogService;
        public BlogController()
        {
            _blogService = new BlogEFCoreService();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var model = _blogService.GetBlogs();
            if(model is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(string id)
        {
            var model = _blogService.GetBlog(id);
            if (model is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult PostBlog([FromBody] BlogModel requestModel)
        {
            var model = _blogService.CreateBlog(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPatch]
        public IActionResult PatchBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;
            var model = _blogService.UpdateBlog(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPut]
        public IActionResult PutBlog(string id, BlogModel requestModel)
        {
            requestModel.BlogId = id;
            var model = _blogService.UpSertBlog(requestModel);
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
}
