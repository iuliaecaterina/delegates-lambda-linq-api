using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Delegate;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDelegateController : ControllerBase
    {
        private readonly IDelegateService _delegateService;

        public TestDelegateController(IDelegateService delegateService)
        {
            _delegateService = delegateService;
        }

        [HttpGet("intro")]
        public string Introduction(string name)
        {
            var callback = _delegateService.Hello;

            return _delegateService.Introduction(name, callback);
        }

        [HttpGet("intro-condition")]
        public string IntroConditional(string name, bool welcome)
        {
            Func<string, string, string> goodbye = _delegateService.Bye;

            Func<string, string, string> callback = welcome
                ? _delegateService.Hello
                : goodbye;

            return _delegateService.Introduction(name, callback);
        }
        [HttpGet("intro-lambda")]
        public string IntroLambda(string name)
        {
            // Lambda expression
            Func<string, string, string> lambda = (first, role) => $"[Lambda] Welcome {first} to the {role} portal.";
            return _delegateService.Introduction(name, lambda);
        }
        [HttpGet("multi")]
        public IActionResult Multicast(string name)
        {
            var messages = _delegateService.NotifyAll(name);
            return Ok(messages);
        }
    }
}
