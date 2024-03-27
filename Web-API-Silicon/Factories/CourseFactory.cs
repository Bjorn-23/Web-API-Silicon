using Infrastructure.Entity;
using System.ComponentModel.DataAnnotations;
using Web_API_Silicon.Models;

namespace Web_API_Silicon.Factories;

public class CourseFactory
{
    public static CourseEntity Create(CreateCourseDto dto)
    {
        CourseEntity entity = new()
        {
            Title = dto.Title,
            Author = dto.Author,
            ImageUrl = dto.ImageUrl,
            AltText = dto.AltText,
            BestSeller = dto.BestSeller,
            Currency = dto.Currency,
            Price = dto.Price,
            DiscountPrice = dto.DiscountPrice,
            LengthInHours = dto.LengthInHours,
            Rating = dto.Rating,
        };
        
        return entity;
    }

    public static CourseEntity Create(ReturnCourseDto dto)
    {
        CourseEntity entity = new()
        {
            Id = dto.Id,
            Title = dto.Title,
            Author = dto.Author,
            ImageUrl = dto.ImageUrl,
            AltText = dto.AltText,
            BestSeller = dto.BestSeller,
            Currency = dto.Currency,
            Price = dto.Price,
            DiscountPrice = dto.DiscountPrice,
            LengthInHours = dto.LengthInHours,
            Rating = dto.Rating,
        };

        return entity;
    }

    public static ReturnCourseDto Create(CourseEntity entity)
    {
        ReturnCourseDto dto = new()
        {
            Id = entity.Id,
            Title = entity.Title,
            Author = entity.Author,
            ImageUrl = entity.ImageUrl,
            AltText = entity.AltText,
            BestSeller = entity.BestSeller,
            Currency = entity.Currency,
            Price = entity.Price,
            DiscountPrice = entity.DiscountPrice,
            LengthInHours = entity.LengthInHours,
            Rating = entity.Rating,
        };

        return dto;
    }

    public static IEnumerable<ReturnCourseDto> Create(IEnumerable<CourseEntity> entities)
    {
        List<ReturnCourseDto> dtos = [];

        foreach (var entity in entities)
        {
            dtos.Add(new ReturnCourseDto()
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                ImageUrl = entity.ImageUrl,
                AltText = entity.AltText,
                BestSeller = entity.BestSeller,
                Currency = entity.Currency,
                Price = entity.Price,
                DiscountPrice = entity.DiscountPrice,
                LengthInHours = entity.LengthInHours,
                Rating = entity.Rating,
            });
        }
        
        return dtos;
    }

}
