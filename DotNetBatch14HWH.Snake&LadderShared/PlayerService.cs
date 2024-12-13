using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.SnakeLadderShared
{
    public class PlayerService
    {
        AppDbCotext db;
        public PlayerService()
        {
            db = new AppDbCotext();
        }

        public ResponseModel RegisterPlayer(PlayerModel requestPlayer)
        {
            db.Players.Add(requestPlayer);
            int result = db.SaveChanges();

            string message = result > 0 ? "Registration Success" : "Registration Fail";
            ResponseModel model = new ResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;
            return model;
        }

        public ResponseModel LoginPlayer(PlayerModel requestPlayer)
        {
            var item = db.Players.AsNoTracking().Where(x => x.PlayerName == requestPlayer.PlayerName).FirstOrDefault();
            if (item is null)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = requestPlayer.PlayerName + " doesn't register the account"
                };
            }
            if (requestPlayer.Password != item.Password)
            {
                return new ResponseModel()
                {
                    IsSuccess = false,
                    Message = "Invalid Password"
                };
            }
            ResponseModel model = new ResponseModel();

            model.IsSuccess = true;
            model.Message = "Login Success";
            return model;
        }

    }
}
