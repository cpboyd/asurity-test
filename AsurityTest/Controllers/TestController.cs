using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsurityTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AsurityTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IStateTest _test;

        public TestController(ILogger<TestController> logger, IStateTest test)
        {
            _logger = logger;
            _test = test;
        }

        [HttpGet]
        public ActionResult Test()
        {
            return Ok();
        }

        [HttpPost]
        public IEnumerable<TestResult> Verify([FromBody] TestInput input)
        {
            return _test.Verify(input);
        }
    }
}