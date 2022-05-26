using WebApi.Common;

namespace WebApi.DataParser
{
    public class TestDataParser1 : IDataParser
    {
        public string GetParserName()
        {
            return DataParserConstants.TestDataParser1;
        }

        public string parse()
        {
            var result = QueryContext.Get("testDatasourceResult1");
            return result.ToString() + "dataParser1 finished";
        }
    }
}
