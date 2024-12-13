using DotNetBatch14HWH.Snake_LadderShared;
using DotNetBatch14HWH.SnakeLadderShared;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14HWH.RestApi7Snake_Ladder.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendInvitationController : ControllerBase
    {
        public readonly FriendInvitation _Service;
        public FriendInvitationController()
        {
            _Service = new FriendInvitation();
        }

        [HttpPost("FriendInvitation")]
        public IActionResult FriendInvitation(GameInvitationModel requestModel)
        {
            try
            {
                var model = _Service.InviteFriend(requestModel);
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
