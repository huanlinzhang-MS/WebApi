namespace WebApi.Controllers
{
    public class TestRequest
    {
        public string? Vertical { get; set; }

        public string? Settings { get; set; }

        public List<string>? Plugins { get; set; }

        public string? QueryFlowKey { get; set; }
    }
}
