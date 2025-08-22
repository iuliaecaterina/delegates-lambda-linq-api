using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Lambda;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLambdaController : ControllerBase
    {
        private readonly ILambdaService _lambdaService;

        public TestLambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpGet("split-number")]
        public string SplitNumber(int value)
        {
            var t = _lambdaService.SplitNumber(value);
            return $"{t.Item1} / {t.Item2} / {t.Item3}";
        }

        [HttpGet("try-parse-number")]
        public string TryParseNumber(string value)
        {
            return _lambdaService.TryParseNumber(value) ? "Number" : "Not number";
        }

        [HttpGet("lower-case-delayed")]
        public async Task<string> ToLowerCaseDelayed(string value)
        {
            return await _lambdaService.ToLowerCaseDelayed(value);
        }

        [HttpGet("lambda-no-param")]
        public string NoParam() => _lambdaService.NoParamLambda();

        [HttpGet("lambda-no-param-block")]
        public string NoParamBlock() => _lambdaService.NoParamLambdaBlock();

        [HttpGet("lambda-one-param")]
        public string OneParam(string name) => _lambdaService.OneParamLambda(name);

        [HttpGet("lambda-one-param-block")]
        public string OneParamBlock(string name) => _lambdaService.OneParamLambdaBlock(name);

        [HttpGet("lambda-async-block")]
        public async Task<string> AsyncBlock(string value) => await _lambdaService.AsyncLambdaBlock(value);

        [HttpGet("two-param")]
        public string TwoParams(int a, int b) => _lambdaService.TwoParams(a, b);

        [HttpGet("unused-param")]
        public string UnusedParam(string action, string name, string ignored) =>
            _lambdaService.UnusedParam(action, name, ignored);

        [HttpPost("default-value")]
        public List<int> DefaultValue([FromBody] List<int> list, [FromQuery] bool desc = false) =>
            _lambdaService.DefaultParam(list, desc);


        [HttpGet("tuple-param")]
        public string TupleParam(int x, int y) => _lambdaService.TupleLambda((x, y));

    }
}
