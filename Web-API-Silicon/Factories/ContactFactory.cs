using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using Web_API_Silicon.Models;

namespace Web_API_Silicon.Factories;

public class ContactFactory
{
    public static ContactEntity Create(CreateContactDto dto)
    {
        ContactEntity entity = new()
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Message = dto.Message,
            Services = dto.Services,
        };

        return entity;
    }

    public static ContactEntity Create(ReturnContactDto dto)
    {
        ContactEntity entity = new()
        {
            Id = dto.Id,
            FullName = dto.FullName,
            Email = dto.Email,
            Message = dto.Message,
            Services = dto.Services,
        };

        return entity;
    }

    public static ReturnContactDto Create(ContactEntity entity)
    {
        ReturnContactDto dto = new()
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Email = entity.Email,
            Message = entity.Message,
            Services = entity.Services,
        };

        return dto;
    }

    public static IEnumerable<ReturnContactDto> Create(IEnumerable<ContactEntity> entities)
    {
        List<ReturnContactDto> dtos = [];

        foreach (var entity in entities)
        {
            dtos.Add(new ReturnContactDto()
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Message = entity.Message,
                Services = entity.Services,
            });
        }

        return dtos;
    }

}

