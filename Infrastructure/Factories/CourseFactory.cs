using Infrastructure.Entities;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class CourseFactory
{
    public static CourseEntity Create(CreateCourseDto dto)
    {
        try
        {
            return new CourseEntity
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
                NumberOfReviews = dto.NumberOfReviews,
                NumberOfLikes = dto.NumberOfLikes,
                CategoryId = dto.CategoryId,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public static CourseEntity Create(ReturnCourseDto dto)
    {
        try
        {
            return new CourseEntity
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
                NumberOfReviews = dto.NumberOfReviews,
                NumberOfLikes = dto.NumberOfLikes,
                CategoryId = dto.CategoryId,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public static ReturnCourseDto Create(CourseEntity entity)
    {
        try
        {
            return new ReturnCourseDto
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
                NumberOfReviews = entity.NumberOfReviews,
                NumberOfLikes = entity.NumberOfLikes,
                CategoryId = entity.CategoryId,
                Category = entity.Category == null ? "" : entity.Category!.CategoryName
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message);  }
        return null!;
    }

    public static IEnumerable<ReturnCourseDto> Create(IEnumerable<CourseEntity> entities)
    {
        try
        {
            List<ReturnCourseDto> dtos = [];

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
