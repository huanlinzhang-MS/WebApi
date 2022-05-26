namespace WebApi.Common
{
    public class ServiceException: Exception
    {
        public ServiceException(string message): base(message)
        {
        }
    }
}
