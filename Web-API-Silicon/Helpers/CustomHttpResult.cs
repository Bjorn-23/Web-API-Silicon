using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Web_API_Silicon.Utilities;

public class CustomHttpResult(StatusCode? responseResult) : IActionResult
{
    private readonly StatusCode? _statusCode = responseResult;

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var statusCodeResult = new StatusCodeResult((int)_statusCode!);
        await statusCodeResult.ExecuteResultAsync(context);
    }
}
