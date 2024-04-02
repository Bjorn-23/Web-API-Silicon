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

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetOneContactForm(string Id)
    {
        var result = await _contactService.GetContactByIdAsync(Id);
        if (result != null)
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

    [HttpPut]
    public async Task<IActionResult> UpdateContact(ReturnContactDto dto)
    {

        var result = await _contactService.UpdateContactAsync(ContactFactory.Create(dto));
        if (result != null)
        {
            return Ok(ContactFactory.Create(result));
        }

        return BadRequest();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteContact(string Id)
    {
        if (ModelState.IsValid)
        {
            var result = await _contactService.DeleteContactAsync(Id);
            if (result != null)
            {
                return Ok(ContactFactory.Create(result));
            }
        }

        return BadRequest();
    }
}
