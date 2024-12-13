using DotNetBatch14HWH.SnakeLadderShared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.Snake_LadderShared
{
    public class PlayGameService
    {
        AppDbCotext db;
        public PlayGameService()
        {
            db = new AppDbCotext();
        }

        public ResponseModel PlayGame(GameInvitationModel requestModel)
        {
            ResponseModel model = new ResponseModel();
            int playerId = 0;
            playerId = (int)requestModel.InvitorId!;
            playerId = (int)requestModel.InviteeId!;

            //For Invitor
            var GameItem = db.GameInvitation.AsNoTracking().Where(x => x.GameId == requestModel.GameId 
            && x.InvitorId == requestModel.InvitorId || x.InviteeId == requestModel.InviteeId).FirstOrDefault();

            if (GameItem is null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Please check the game create or not"
                };
            }
            var Player = db.Players.AsNoTracking().Where(x => x.PlayerID == playerId).FirstOrDefault();
            if (Player is null)
            {
                model.IsSuccess = false;
                model.Message = "The player doesn't active.";

                return model;
            }
            int oldPosition = (int)Player.CurrentPosition!;

            int nextRandom = RollDice();
            int ActualMoveNewPosition = 0;

            int newPosition = oldPosition + nextRandom;

            var getcell = db.GameBoards.AsNoTracking().Where(x => x.CellNumber == newPosition).FirstOrDefault();
            if (getcell.CellType == "Normal")
            {
                ActualMoveNewPosition = newPosition;
                Player.CurrentPosition = ActualMoveNewPosition;
            }
            if (getcell.CellType == "LadderBottom")
            {
                ActualMoveNewPosition = newPosition + getcell.MoveToCell;
                Player.CurrentPosition = ActualMoveNewPosition;

            }
            if (getcell.CellType == "SnakeHead")
            {
                ActualMoveNewPosition = newPosition - getcell.MoveToCell;
                Player.CurrentPosition = ActualMoveNewPosition;
            }

            db.Entry(Player).State = EntityState.Modified;

            GameMoveModel gameMove = new GameMoveModel();
            if(requestModel.InvitorId is null)
            {
                gameMove.PlayerID = (int)requestModel.InviteeId;
                gameMove.GameID = (int)requestModel.GameId!;
                gameMove.FromCell = oldPosition;
                gameMove.ToCell = newPosition;
                gameMove.MoveDate = DateTime.Now;
            }
            if (requestModel.InviteeId is null)
            {
                gameMove.PlayerID = (int)requestModel.InvitorId!;
                gameMove.GameID = (int)requestModel.GameId!;
                gameMove.FromCell = oldPosition;
                gameMove.ToCell = newPosition;
                gameMove.MoveDate = DateTime.Now;
            }

            db.GameMoves.Add(gameMove);

            int result = db.SaveChanges();

            var lst = db.GameBoards.AsNoTracking().ToList();
            if(lst.Count <= ActualMoveNewPosition)
            {                
                model.IsSuccess = result > 0;
                model.Message = "Game Win by " + gameMove.PlayerID;

                return model;
            }
            string message = result > 0 ? "Game Move successfully" : "Game Move fail";
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
        private int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }
    }
}
