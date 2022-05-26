using WebApi.Common;

namespace WebApi.DataSource
{
    public class TestDataSource : IDataSource
    {
        public string GetDataSourceName()
        {
            return DataSourceConstants.TestDataSource;
        }

        [DatasourceResource(resourceName:"datasourceResource1")]
        public void InvokeDatasource1()
        {
            QueryContext.Put("testDatasourceResult1", "datasourceResource1");
        }

        [DatasourceResource(resourceName: "datasourceResource2")]
        public void InvokeDatasource2()
        {
            QueryContext.Put("testDatasourceResult2", "datasourceResource2");
        }
    }
}
