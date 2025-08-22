using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestLinqController : ControllerBase
    {
        private readonly ILinqService _linqService;

        public TestLinqController(ILinqService linqService)
        {
            _linqService = linqService;
        }

        [HttpGet("count-method")]
        public int CountStudentsMethod(int age)
        {
            return _linqService.CountStudentsOver_Method(age);
        }

        [HttpGet("count-query")]
        public int CountStudentsQuery(int age)
        {
            return _linqService.CountStudentsOver_Query(age);
        }

        [HttpGet("filter-by-group")]
        public List<Student> FilterByGroup(string groupName)
        {
            return _linqService.FilterByGroup(groupName);
        }

        [HttpGet("emails")]
        public List<string> SelectEmails()
        {
            return _linqService.SelectEmails();
        }

        [HttpGet("nota-minima")]
        public List<Student> FilterByNota(double minNota)
        {
            return _linqService.FilterByNota(minNota);
        }

        [HttpGet("join")]
        public List<string> JoinWithGroups()
        {
            return _linqService.JoinWithGroups();
        }
    }
}
