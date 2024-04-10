using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Web_API_Silicon.Helpers;

public class StatusCodeSelector : ControllerBase
{
    /// <summary>
    /// Genereates a http Statusmessage from correspponding ResponseResult.
    /// </summary>
    /// <param name="response"></param>
    /// <returns></returns>
    public IActionResult StatusSelector(ResponseResult response)
    {
        switch (response.StatusCode)
        {
            case Infrastructure.Utilities.StatusCode.OK:
                return Ok();
            case Infrastructure.Utilities.StatusCode.CREATED:
                return Created("", response.Content);
            case Infrastructure.Utilities.StatusCode.NO_CONTENT:
                return NoContent();
            case Infrastructure.Utilities.StatusCode.BAD_REQUEST:
                return BadRequest();
            case Infrastructure.Utilities.StatusCode.UNAUTHORIZED:
                return Unauthorized();
            case Infrastructure.Utilities.StatusCode.FORBIDDEN:
                return Forbid();
            case Infrastructure.Utilities.StatusCode.NOT_FOUND:
                return NotFound();
            case Infrastructure.Utilities.StatusCode.METHOD_NOT_ALLOWED:
                return StatusCode(405, "Method Not Allowed");
            case Infrastructure.Utilities.StatusCode.EXISTS:
                return Conflict("Resource already exists");
            case Infrastructure.Utilities.StatusCode.UNSUPPORTED_MEDIA_TYPE:
                return StatusCode(415, "Unsupported Media Type");
            case Infrastructure.Utilities.StatusCode.NOT_INPLEMENTED:
                return StatusCode(501, "Not Implemented");
            case Infrastructure.Utilities.StatusCode.SERVICE_UNAVAILABLE:
                return StatusCode(503, "Service Unavailable");
            default:
                return StatusCode(500, "Internal Server Error");
        }
    }
}
