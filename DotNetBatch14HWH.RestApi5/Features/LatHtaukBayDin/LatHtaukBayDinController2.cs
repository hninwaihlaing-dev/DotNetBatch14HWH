using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetBatch14HWH.RestApi5.Features.LatHtaukBayDin;

[Route("api/[controller]")]
[ApiController]
public class LatHtaukBayDinController2 : ControllerBase
{
    private async Task<LatHtaukBayDin> GetDataAsync()
    {
        string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
        var model = JsonConvert.DeserializeObject<LatHtaukBayDin>(jsonStr);
        return model;
    }

    [HttpGet("questions")]
    public async Task<IActionResult> GetQuestion()
    {
        var model = await GetDataAsync();
        return Ok(model.questions);
    }

    [HttpGet]
    public async Task<IActionResult> NumberList()
    {
        var model = await GetDataAsync();
        return Ok(model.numberList);
    }

    [HttpGet("{questionNo}/{answerNo}")]
    public async Task<IActionResult> Result(int questionNo, int answerNo)
    {
        var model = await GetDataAsync();
        return Ok(model.answers.FirstOrDefault(x=> x.questionNo == questionNo && x.answerNo == answerNo));
    }
}