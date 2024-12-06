using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetBatch14HWH.RestApi5.Features.LatHtaukBayDin
{
    public class LatHtaukBayDinController3 : ControllerBase
    {
        private async Task<LatHtaukBayDin> GetAsync()
        {
            string jsonStr = await System.IO.File.ReadAllTextAsync("data.json");
            var model = JsonConvert.DeserializeObject<LatHtaukBayDin>(jsonStr);

            return model!;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetQuestions()
        {
            var model = await GetAsync();
            return Ok(model.questions);
        }

        [HttpGet("NumberList")]
        public async Task<IActionResult> GetNumberList()
        {
            var model = await GetAsync();   
            return Ok(model.numberList);
        }

        [HttpGet("{questionNo}/{numberList}")]
        public async Task<IActionResult> GetAnswer(int questionNo, int numberList)
        {
            var model = await GetAsync();
            return Ok(model.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == numberList));
        }
    }
}
