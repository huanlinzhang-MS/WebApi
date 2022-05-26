using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebApi.TestService;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private ITestService _testService;

        private QueryGlobalManager _queryGlobalManager;

        public TestController(ITestService testService, QueryGlobalManager queryGlobalManager)
        {
            _testService = testService;
            _queryGlobalManager = queryGlobalManager;
        }

        [HttpGet(template:"testFunc")]
        public TestModule TestFunc()
        {
            return _testService.TestFunc();
        }

        [HttpGet(template: "DataParserParse")]
        public string DataParserParse(string parserName)
        {
            var type = typeof(TestModule);
            var methods = type.GetMethods();
            var method = methods.First();
            return _testService.DataPaserParse(parserName);
        }

        [HttpGet(template:"testQueryFlow")]
        public string TestQueryFlow(string queryFlowKey)
        {
            var request = new TestRequest();
            request.Vertical = "WebAnswer";
            request.Settings = "settings";
            request.Plugins = new List<string>() { "1", "2"};
            request.QueryFlowKey = queryFlowKey;
            return _queryGlobalManager.Query(request);
        }
    }
}
