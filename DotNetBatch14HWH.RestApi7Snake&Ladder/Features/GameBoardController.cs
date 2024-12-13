using DotNetBatch14HWH.Snake_LadderShared;
using DotNetBatch14HWH.SnakeLadderShared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14HWH.RestApi7Snake_Ladder.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameBoardController : ControllerBase
    {
        public readonly GameBoardService _Service;
        public GameBoardController()
        {
            _Service = new GameBoardService();
        }

        [HttpPost("CreateGameBoard")]
        public IActionResult CreateGameBoar(GameBoardModel requestGameBoard)
        {
            try
            {
                var model = _Service.CreateGameBoard(requestGameBoard);
                if(!model.IsSuccess)
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
