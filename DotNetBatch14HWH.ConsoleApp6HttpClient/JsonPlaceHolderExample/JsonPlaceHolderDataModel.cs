using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.ConsoleApp6HttpClient.JsonPlaceHolderExample;

public class JsonPlaceHolderDataModel
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string body { get; set; }
}

public class ResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
