using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Web_API_Silicon.Helpers;

public class CustomHttpResult(StatusCode? responseResult) : IActionResult
{
    private readonly StatusCode? _statusCode = responseResult;

    /// <summary>
    /// Can be used to send custom statusCodes.
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task ExecuteResultAsync(ActionContext context)
    {
        var statusCodeResult = new StatusCodeResult((int)_statusCode!);
        await statusCodeResult.ExecuteResultAsync(context);
    }
}
