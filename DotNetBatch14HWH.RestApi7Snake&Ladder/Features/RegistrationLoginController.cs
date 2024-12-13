using DotNetBatch14HWH.SnakeLadderShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DotNetBatch14HWH.RestApi7SnakeLadder.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationLoginController : ControllerBase
    {
        private readonly PlayerService _Service;
        public RegistrationLoginController()
        {
            _Service = new PlayerService();
        }

        [HttpPost]
        public IActionResult RegisterPlayer([FromBody] PlayerModel requestPlayer)
        {
            try
            {
                var model = _Service.RegisterPlayer(requestPlayer);
                if(!model.IsSuccess)
                {
                    return BadRequest(model);
                }
                return Ok(model);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResponseModel()
                {
                    Message = ex.Message.ToString()
                });
            }
        }

        [HttpPost("LoginPlayer")]
        public IActionResult LoginPlayer([FromBody] PlayerModel requestPlayer)
        {
            try
            {
                var model = _Service.LoginPlayer(requestPlayer);
                if (!model.IsSuccess)
                {
                    return BadRequest(model);
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel()
                {
                    Message = ex.Message.ToString()
                });
            }
        }
    }
}
