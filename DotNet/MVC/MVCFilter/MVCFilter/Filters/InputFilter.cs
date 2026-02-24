using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCFilter.Filters
{
    public class SanitizeInputFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var key in context.ActionArguments.Keys.ToList())
            {
                
            }
        }
    }

    public class InputFilter
    {

    }
}
