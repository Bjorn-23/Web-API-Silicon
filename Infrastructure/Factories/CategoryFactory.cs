using Infrastructure.Entities;
using Infrastructure.Models;
using System.Diagnostics;

namespace Infrastructure.Factories;

public class CategoryFactory
{
    public static CategoryEntity Create(CategoryModel model)
    {
        try
        {
            return new CategoryEntity
            {
                Id = model.Id,
                CategoryName = model.CategoryName,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public static CategoryModel Create(CategoryEntity entity)
    {
        try
        {
            return new CategoryModel
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public static IEnumerable<CategoryModel> Create(IEnumerable<CategoryEntity> entities)
    {
        List<CategoryModel> models = [];

        try
        {
            foreach (var entity in entities)
            {
                models.Add(Create(entity));
            }

            return models;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

}
