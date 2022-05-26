using System.Reflection;

namespace WebApi.DataParser
{
    public class DataParserManager
    {
        public Dictionary<string, IDataParser> dataPaserDic = new Dictionary<string, IDataParser>();

        public DataParserManager()
        {
            var dataParserList = AppDomain.CurrentDomain.GetAssemblies()
                                               .SelectMany(a => a.GetTypes()
                                                                 .Where(t => t.GetInterfaces()
                                                                 .Contains(typeof(IDataParser))))
                                               .ToList();
            foreach(Type dataParser in dataParserList)
            {
                var parser = (IDataParser)Activator.CreateInstance(dataParser);
                dataPaserDic.Add(parser.GetParserName(), parser);
            }
        }

        public string InvokeDataParser(string parserName)
        {
            return dataPaserDic[parserName].parse();
        }


    }
}
