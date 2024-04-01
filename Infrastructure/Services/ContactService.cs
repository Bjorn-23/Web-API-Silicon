using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ContactService(ContactRepository repository)
{
    private readonly ContactRepository _repository = repository;

    public async Task<ContactEntity> CreateContactAsync(ContactEntity entity)
    {
        try
        {            
            var result = await _repository.CreateAsync(entity);
            if (result != null)
            {
                return result;
            }

            //return 409 conflict
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

    public async Task<IEnumerable<ContactEntity>> GetContactByIdAsync(string Id)
    {
        try
        {
            var existingContacts = await _repository.GetAllWithPredicateAsync(x => x.Email == Id);
            if (existingContacts != null)
            {
                return existingContacts;
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

    public async Task<ContactEntity> UpdateContactAsync(ContactEntity updatedEntity)
    {
        try
        {
            var existingContact = await _repository.GetOneAsync(x => x.Id == updatedEntity.Id);
            if (existingContact != null)
            {
                var result = await _repository.UpdateAsync(existingContact, updatedEntity);
                if (result != null)
                {
                    return result;
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    public async Task<ContactEntity> DeleteCourseAsync(string Id)
    {
        try
        {
            var existingContact = await _repository.GetOneAsync(x => x.Id == Id);
            if (existingContact != null)
            {
                var result = await _repository.DeleteAsync(existingContact);
                if (result)
                {
                    return existingContact;
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }
}
