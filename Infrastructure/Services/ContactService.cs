using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Repositories;
using Infrastructure.Utilities;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ContactService(ContactRepository repository)
{
    private readonly ContactRepository _repository = repository;

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
