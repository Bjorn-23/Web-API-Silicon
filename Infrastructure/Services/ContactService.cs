using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories;
using Infrastructure.Utilities;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ContactService(ContactRepository repository)
{
    private readonly ContactRepository _repository = repository;

    /// <summary>
    /// Sends data to repository to create a new contact message in database.
    /// </summary>
    /// <param name="entity">The contact message to be created.</param>
    /// <returns>A custom reponseresult with http statuscode and the created contact message</returns>
    public async Task<ResponseResult> CreateContactAsync(ContactEntity entity)
    {
        try
        {            
            var result = await _repository.CreateAsync(entity);
            if (result != null)
            {
                return ResponseFactory.Created(result);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;

    }

    /// <summary>
    /// Gets one contact message from the database.
    /// </summary>
    /// <param name="email">The email of the contact messages to look for</param>
    /// <returns>List of the corresponding contact messages or null.</returns>
    public async Task<IEnumerable<ContactEntity>> GetContactByEmailAsync(string email)
    {
        try
        {
            var existingContacts = await _repository.GetAllWithPredicateAsync(x => x.Email == email);
            if (existingContacts != null)
            {
                return existingContacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;

    }

    /// <summary>
    /// Get one contact message from the database.
    /// </summary>
    /// <param name="id">The Id of the contact message to look for.</param>
    /// <returns>The corresponding contact message or null.</returns>
    public async Task<ContactEntity> GetContactByIdAsync(string id)
    {
        try
        {
            var existingContact = await _repository.GetOneAsync(x => x.Id == id);
            if (existingContact != null)
            {
                return existingContact;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;

    }

    /// <summary>
    /// Get all contact messages from database.
    /// </summary>
    /// <returns>All contact messages in database or null if there are less than one.</returns>
    public async Task<IEnumerable<ContactEntity>> GetAllContactsAsync()
    {
        try
        {
            var allExistingContacts = await _repository.GetAllAsync();
            if (allExistingContacts.Count() > 0)
            {
                return allExistingContacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;

    }

    /// <summary>
    /// Updates a contact message in the database. For admin purposes only.
    /// </summary>
    /// <param name="updatedEntity"></param>
    /// <returns></returns>
    public async Task<ResponseResult> UpdateContactAsync(ContactEntity updatedEntity)
    {
        try
        {
            var existingContact = await _repository.GetOneAsync(x => x.Id == updatedEntity.Id);
            if (existingContact != null)
            {
                var result = await _repository.UpdateAsync(existingContact, updatedEntity);
                if (result != null)
                {
                    return ResponseFactory.Ok(result);
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    /// <summary>
    /// Deletes one contact message in the database.
    /// </summary>
    /// <param name="Id">Id of the contact message to be deleted</param>
    /// <returns>The deleted contact message</returns>
    public async Task<ResponseResult> DeleteContactAsync(string Id)
    {
        try
        {
            var existingContact = await _repository.GetOneAsync(x => x.Id == Id);
            if (existingContact != null)
            {
                var result = await _repository.DeleteAsync(existingContact);
                if (result)
                {
                    return ResponseFactory.Ok(result);
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
