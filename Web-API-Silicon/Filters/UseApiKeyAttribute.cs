using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web_API_Silicon.Filters;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{
    /// <summary>
    /// Checks API Key and authorizes.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = configuration.GetValue<string>("ApiKey:Secret");

        if (!context.HttpContext.Request.Query.TryGetValue("key", out var providedKey)) // Chekcs for key value pari in query. Change here from Query to Headers if you want to use headers.
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!apiKey!.Equals(providedKey)) //compares submited key to stored key
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
