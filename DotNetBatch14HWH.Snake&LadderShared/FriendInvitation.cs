using DotNetBatch14HWH.SnakeLadderShared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.Snake_LadderShared
{
    public class FriendInvitation
    {
        AppDbCotext db;
        public FriendInvitation()
        {
            db = new AppDbCotext();
        }

        public ResponseModel InviteFriend(GameInvitationModel requestModel)
        {
            var item = db.Games.AsNoTracking().Where(x => x.GameID == requestModel.GameId &&
            x.GameStatus == "Initial" && x.CurrentPlayerID == requestModel.InvitorId).FirstOrDefault();

            if (item is null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Please check the game create or not"
                };
            }
            var playerId = db.Players.AsNoTracking().Where(x => x.PlayerID == requestModel.InviteeId).FirstOrDefault();
            if (playerId is null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "This player doesn't active"
                };
            }
            playerId.CurrentPosition = 1;
            db.Entry(playerId).State = EntityState.Modified;

            db.GameInvitation.Add(requestModel);
            int result = db.SaveChanges();
            string message = result > 0 ? "Friend Invitation Success" : "Friend Invitation Fail";
            ResponseModel model = new ResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
    }
}
