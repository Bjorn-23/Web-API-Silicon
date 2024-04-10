using Infrastructure.Entities;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class ContactFactory
{
    public static ContactEntity Create(CreateContactDto dto)
    {
        try
        {
            return new ContactEntity
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Message = dto.Message,
                Services = dto.Services,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;

    }

    public static ContactEntity Create(ReturnContactDto dto)
    {
        try
        {
            return new ContactEntity
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Email = dto.Email,
                Message = dto.Message,
                Services = dto.Services,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public static ReturnContactDto Create(ContactEntity entity)
    {
        try
        {
            return new ReturnContactDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Message = entity.Message,
                Services = entity.Services,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public static IEnumerable<ReturnContactDto> Create(IEnumerable<ContactEntity> entities)
    {
        try
        {
            List<ReturnContactDto> dtos = [];

            foreach (var entity in entities)
            {
                dtos.Add(Create(entity));
            }

            return dtos;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

}

