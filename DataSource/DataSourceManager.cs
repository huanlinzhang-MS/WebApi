using System.Reflection;
using WebApi.Common;

namespace WebApi.DataSource
{
    public class DataSourceManager
    {

        public Dictionary<string, IDataSource> dataSourceDic = new Dictionary<string, IDataSource>();

        public Dictionary<string, MethodInfo> datasourceResourceDic = new Dictionary<string, MethodInfo>();

        public DataSourceManager()
        {
            var dataSourceList = AppDomain.CurrentDomain.GetAssemblies()
                                               .SelectMany(a => a.GetTypes()
                                                                 .Where(t => t.GetInterfaces()
                                                                 .Contains(typeof(IDataSource))))
                                               .ToList();
            foreach (Type dataSourceType in dataSourceList)
            {
                var datasourceInstance = Activator.CreateInstance(dataSourceType);

                if (datasourceInstance == null)
                {
                    continue;
                }

                var datasource = (IDataSource)datasourceInstance;
                dataSourceDic.Add(datasource.GetDataSourceName(), datasource);

                var methods = dataSourceType.GetMethods();
                foreach (MethodInfo methodInfo in methods)
                {
                    var resource = methodInfo.GetCustomAttribute<DatasourceResource>();
                    if (resource != null)
                    {
                        datasourceResourceDic.Add(ConvertDatasourceResourceName(datasource.GetDataSourceName(), resource.ResourceName), methodInfo);
                    }
                }
            }
        }

        private string ConvertDatasourceResourceName(string datasourceName, string resourceName)
        {
            return datasourceName + "_" + resourceName;
        }

        public void InvokeDataSource(QueryFlowConfig queryFlow)
        {
            var datasource = dataSourceDic[queryFlow.datasourceName];
            var resourceMethod = datasourceResourceDic[ConvertDatasourceResourceName(queryFlow.datasourceName, queryFlow.resourceName)];

            resourceMethod.Invoke(datasource, null);
        }
    }
}
