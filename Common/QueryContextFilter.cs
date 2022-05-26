using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Common
{
    public class QueryContextFilter : IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            QueryContext.clear();
        }
    }
}
