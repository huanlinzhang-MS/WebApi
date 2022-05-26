using Newtonsoft.Json;
using WebApi.Common;
using WebApi.Controllers;
using WebApi.DataParser;
using WebApi.DataSource;

namespace WebApi
{
    public class QueryGlobalManager
    {

        private DataSourceManager _dataSourceManager;

        private DataParserManager _dataParserManager;

        private IConfiguration _configuration;

        public QueryGlobalManager(DataSourceManager dataSourceManager, DataParserManager dataParserManager, IConfiguration configuration)
        {
            _dataSourceManager = dataSourceManager;
            _dataParserManager = dataParserManager;
            _configuration = configuration;
        }

        public string Query(TestRequest request)
        {
            InitQueryContext(request);
            var queryFlow = JsonConvert.DeserializeObject<QueryFlowConfig>(_configuration[request.QueryFlowKey]);
            if (queryFlow == null) throw new ServiceException("queryflow is ivalid");
            _dataSourceManager.InvokeDataSource(queryFlow);
            return _dataParserManager.InvokeDataParser(queryFlow.dataPaserName);
        }

        private void InitQueryContext(TestRequest requset)
        {
            QueryContext.Put(ContextConstants.Vertical, requset.Vertical);
            QueryContext.Put(ContextConstants.Settings, requset.Settings);
            QueryContext.Put(ContextConstants.Plugins, requset.Plugins);
        }
    }
}
