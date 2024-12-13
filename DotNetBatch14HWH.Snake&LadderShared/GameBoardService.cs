using DotNetBatch14HWH.SnakeLadderShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.Snake_LadderShared
{
    public class GameBoardService
    {
        AppDbCotext db;
        public GameBoardService()
        {
            db = new AppDbCotext();
        }

        public ResponseModel CreateGameBoard(GameBoardModel requsetGameBoar)
        {
            db.GameBoards.Add(requsetGameBoar);
            int result = db.SaveChanges();

            string message = result > 0 ? "Game Board successfully created" : "Game Board creationg fail";
            ResponseModel model = new ResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
    }
}
