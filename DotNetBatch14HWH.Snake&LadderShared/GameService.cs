using DotNetBatch14HWH.SnakeLadderShared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.Snake_LadderShared
{
    public class GameService
    {
        AppDbCotext db;
        public GameService()
        {
            db = new AppDbCotext();
        }

        public ResponseModel CreateGame(GameModel requestModel)
        {
            PlayerModel playerModel = db.Players.AsNoTracking().Where(x => x.PlayerID == requestModel.CurrentPlayerID).FirstOrDefault()!;
            playerModel.CurrentPosition = 1;
            db.Entry(playerModel).State = EntityState.Modified;

            db.Games.Add(requestModel);
            int result = db.SaveChanges();

            string message = result > 0 ? "Game successfully created" : "Game creation fail";
            ResponseModel model = new ResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

        public ResponseModel PlayGame(GameInvitationModel requestModel)
        {
            ResponseModel model = new ResponseModel();
            int playerId = 0;
            if (requestModel.InvitorId is null)
            {
                playerId = (int)requestModel.InviteeId!;
            }
            if (requestModel.InviteeId is null)
            {
                playerId = (int)requestModel.InvitorId!;
            }

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
            var GameStatus = db.Games.AsNoTracking().Where(x => x.GameID == requestModel.GameId && x.GameStatus == "Completed").FirstOrDefault();
            if (GameStatus is not null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "This game is already played. Please create new game."
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
            //int nextRandom = 11;
            int ActualMoveNewPosition = 0;

            int newPosition = oldPosition + nextRandom;
            int maxCellNumber = db.GameBoards.Max(x => x.CellNumber);
            if (newPosition > maxCellNumber)
            {
                newPosition = maxCellNumber;
            }

            var getcell = db.GameBoards.AsNoTracking().Where(x => x.CellNumber == newPosition).FirstOrDefault();
            //if (getcell.CellType == "Normal")
            //{
            //    ActualMoveNewPosition = newPosition;
            //    Player.CurrentPosition = ActualMoveNewPosition;
            //}
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
            else if (getcell.CellType == "Normal" || getcell.CellType == "LadderTop" || getcell.CellType == "SnakeTail")
            {
                ActualMoveNewPosition = newPosition;
                Player.CurrentPosition = ActualMoveNewPosition;
            }

            db.Entry(Player).State = EntityState.Modified;
            db.SaveChanges();

            GameMoveModel gameMove = new GameMoveModel();
            if (requestModel.InvitorId is null)
            {
                gameMove.PlayerID = (int)requestModel.InviteeId!;
                gameMove.GameID = (int)requestModel.GameId!;
                gameMove.FromCell = oldPosition;
                gameMove.ToCell = ActualMoveNewPosition;
                gameMove.MoveDate = DateTime.Now;
            }
            if (requestModel.InviteeId is null)
            {
                gameMove.PlayerID = (int)requestModel.InvitorId!;
                gameMove.GameID = (int)requestModel.GameId!;
                gameMove.FromCell = oldPosition;
                gameMove.ToCell = ActualMoveNewPosition;
                gameMove.MoveDate = DateTime.Now;
            }

            db.GameMoves.Add(gameMove);

            int result = db.SaveChanges();

            var lst = db.GameBoards.AsNoTracking().ToList();
            if (lst.Count <= ActualMoveNewPosition)
            {
                var gameModel = db.Games.AsNoTracking().Where(x => x.GameID == (int)requestModel.GameId).FirstOrDefault();
                gameModel.GameStatus = "Completed";
                db.Entry(gameModel).State = EntityState.Modified;
                db.SaveChanges();

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
