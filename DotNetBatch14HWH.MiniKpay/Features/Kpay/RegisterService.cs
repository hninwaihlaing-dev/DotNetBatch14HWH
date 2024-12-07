﻿using DotNetBatch14HWH.RestApi5.Features.Transfer;

namespace DotNetBatch14HWH.MiniKpay.Features.Kpay
{
    public class RegisterService
    {
        public AppDbContext db = new AppDbContext();

        public ResponseModel CreateUser(UserModel requestUserModel)
        {
            db.Users.Add(requestUserModel);
            int result = db.SaveChanges();

            string message = result > 0 ? "Create success" : "Create fail";
            ResponseModel model = new ResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }
    }
}
