namespace WebApi.TestService
{
    public interface ITestService
    {

        public TestModule TestFunc();
        public string DataPaserParse(string parserName);
    }
}
