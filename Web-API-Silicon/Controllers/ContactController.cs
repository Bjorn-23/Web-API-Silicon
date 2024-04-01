using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Web_API_Silicon.Factories;
using Web_API_Silicon.Filters;
using Web_API_Silicon.Models;

namespace Web_API_Silicon.Controllers;

[Route("api/[controller]")]
[UseApiKey]
[ApiController]
public class ContactController(ContactService contactService) : Controller
{
    private readonly ContactService _contactService = contactService;

    [HttpGet]
    public async Task<IActionResult> GetAllContactForms()
    {
        var result = await _contactService.GetAllContactsAsync();
        if (result.Count() > 0)
        {
            return Ok(ContactFactory.Create(result));
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateContactForm(CreateContactDto dto)
    {

        var result = await _contactService.CreateContactAsync(ContactFactory.Create(dto));
        if (result != null)
        {
            return Created();
        }
        
        return BadRequest();
    }
}
