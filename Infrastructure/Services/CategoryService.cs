using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Infrastructure.Models;
using System.Diagnostics;
using Infrastructure.Repositories;
using Infrastructure.Factories;

namespace Infrastructure.Services;


public class CategoryService(CategoryRepository repository)
{
    private readonly CategoryRepository _repository = repository;

    /// <summary>
    /// Gets all categories asynchronusly from database.
    /// </summary>
    /// <returns>List of CategoryModel</returns>
    public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync()
    {
        try
        {
            var result = await _repository.GetAllAsync();
            return CategoryFactory.Create(result);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    /// <summary>
    /// Gets a single category from databse.
    /// </summary>
    /// <param name="categoryName">The name of the category to get.</param>
    /// <returns>a single CategoryModel</returns>
    public async Task<CategoryModel> GetOneCategoryAsync(string categoryName)
    {
        try
        {
            var result = await _repository.GetOneAsync(x => x.CategoryName == categoryName);
            return CategoryFactory.Create(result);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    
}
