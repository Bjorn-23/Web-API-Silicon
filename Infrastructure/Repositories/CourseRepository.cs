using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class CourseRepository(DataContext context) : BaseRepo<CourseEntity, DataContext>(context)
{
    private readonly DataContext _context = context;

    public override async Task<CourseResult> GetAllAsync(string? category, string? searchQuery, int pageNumber, int pageSize)
    
    {
        try
        {
            #region QUERIES
            var query = _context.Courses.Include(i => i.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) && category != "all")
            {
                query = query.Where(x => x.Category!.CategoryName == category);
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(x => x.Title.Contains(searchQuery) || x.Author.Contains(searchQuery));
            }

            query = query.OrderBy(i => i.Title);
            #endregion

            #region PAGINATION
            var pagination = new Pagination
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = await query.CountAsync(),
                CurrentPage = pageNumber // is this right?
            };

            pagination.TotalPages = (int)Math.Ceiling(pagination.TotalItems / (double)pageSize);
            var returnCourses = CourseFactory.Create(await query.Skip((pageNumber -1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync());
            #endregion

            if(pagination != null && returnCourses != null)
            {
                return new CourseResult
                {
                    Pagination = pagination,
                    ReturnCourses = returnCourses
                };                
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
