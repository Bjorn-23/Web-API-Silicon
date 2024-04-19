using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Infrastructure.Factories;
using Infrastructure.Models;
using Web_API_Silicon.Filters;
using Web_API_Silicon.Helpers;
using System.Diagnostics;

namespace Web_API_Silicon.Controllers;

[Route("api/[controller]")]
[UseApiKey]
[ApiController]
public class ContactController(ContactService contactService, StatusCodeSelector statusCode) : ControllerBase
{
    private readonly ContactService _contactService = contactService;
    private readonly StatusCodeSelector _statusCode = statusCode;

    #region CREATE
    [HttpPost]
    public async Task<IActionResult> CreateContactForm(CreateContactDto dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                    var result = await _contactService.CreateContactAsync(ContactFactory.Create(dto));
                    if (result != null)
                    {
                        return _statusCode.StatusSelector(result);
                    }
            }

            return BadRequest();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion

    #region READ
    [HttpGet]
    public async Task<IActionResult> GetAllContactForms()
    {
        try
        {
            if (ModelState.IsValid)
            {
                    var result = await _contactService.GetAllContactsAsync();
                    if (result != null)
                    {
                        return Ok(ContactFactory.Create(result));
                    }

                    return NotFound();
            }

            return BadRequest();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetOneContactForm(string Id)
    {
        try
        {
            if (ModelState.IsValid)
            {
                    var result = await _contactService.GetContactByIdAsync(Id);
                    if (result != null)
                    {
                        return Ok(ContactFactory.Create(result));
                    }

                    return NotFound();
            }

            return BadRequest();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion

    #region UPDATE
    [HttpPut]
    public async Task<IActionResult> UpdateContact(ReturnContactDto dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                    var result = await _contactService.UpdateContactAsync(ContactFactory.Create(dto));
                    if (result != null)
                    {
                        return _statusCode.StatusSelector(result);
                    }
                
                    return NotFound();
            }

            return BadRequest();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion

    #region DELETE
    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteContact(string Id)
    {
        try
        {
            if (ModelState.IsValid)
            {
                    var result = await _contactService.DeleteContactAsync(Id);
                    if (result != null)
                    {
                        return _statusCode.StatusSelector(result);
                    }

                    return NotFound();
            }

            return BadRequest();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion
}
