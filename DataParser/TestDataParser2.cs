using WebApi.Common;

namespace WebApi.DataParser
{
    public class TestDataParser2 : IDataParser
    {
        public string GetParserName()
        {
            return DataParserConstants.TestDataParser2;
        }

        public string parse()
        {
            var result = QueryContext.Get("testDatasourceResult2");
            return result.ToString() + "dataParser2 finished";
        }
    }
}
