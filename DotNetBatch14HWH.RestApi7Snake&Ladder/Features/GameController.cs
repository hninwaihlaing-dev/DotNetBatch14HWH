using DotNetBatch14HWH.Snake_LadderShared;
using DotNetBatch14HWH.SnakeLadderShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14HWH.RestApi7Snake_Ladder.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public readonly GameService _Service;
        public GameController()
        {
            _Service = new GameService();
        }

        [HttpPost("CreateGame")]
        public IActionResult CreateGame(GameModel requestModel)
        {
            try
            {
                var model = _Service.CreateGame(requestModel);
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
                    Message = ex.ToString()
                });
            }
        }

        [HttpPost("PlayGame")]
        public IActionResult PlayGame(GameInvitationModel requestModel)
        {
            try
            {
                var model = _Service.PlayGame(requestModel);
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
                    Message = ex.ToString()
                });
            }
        }
    }
}
