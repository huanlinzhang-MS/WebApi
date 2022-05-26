using Newtonsoft.Json;
using WebApi.DataParser;

namespace WebApi.TestService
{
    public class TestServiceImpl : ITestService
    {

        private IConfiguration _configuration;

        private DataParserManager _dataParserManager;

        public TestServiceImpl(IConfiguration configuration, DataParserManager dataParserManager)
        {
            _configuration = configuration;
            _dataParserManager = dataParserManager;
        }

        public TestModule TestFunc()
        {
            return JsonConvert.DeserializeObject<TestModule>(_configuration["test_app_config"]);
        }

        public string DataPaserParse(string parserName)
        {
            return _dataParserManager.dataPaserDic[parserName].parse();
        }
    }
}
