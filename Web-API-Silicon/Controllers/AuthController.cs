using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Web_API_Silicon.Filters;

namespace Web_API_Silicon.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;

    #region READ
    /// <summary>
    /// Generates JWT for admin in web app.
    /// </summary>
    /// <returns>JSON Web Token</returns>
    [UseApiKey]
    [HttpPost]
    public IActionResult GetToken()
    {
        try
        {
            if(ModelState.IsValid)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    Expires = DateTime.Now.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!)), SecurityAlgorithms.HmacSha512),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(tokenHandler.WriteToken(token));
            }

            return Unauthorized();
        }
        catch (Exception ex) {Debug.WriteLine(ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion
}
