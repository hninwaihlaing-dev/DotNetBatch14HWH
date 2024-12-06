namespace DotNetBatch14HWH.RestApi5.Features.Transfer
{
    public interface ITransferService
    {
        TransferResponseModel CreateTransaction(TransactionModel requestTransactionModel, int Password);
        UserModel GetUserData(string MobileNo);

        TransferResponseModel CreateUser(UserModel user);
        List<TransactionModel> GetTransaction(string MobileNo);

    }
}