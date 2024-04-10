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
            // includes Categories in courses entities.
            var query = _context.Courses.Include(i => i.Category).AsQueryable();

            //if no category is selected then by default choose all categories.
            if (!string.IsNullOrWhiteSpace(category) && category != "all")
            {
                query = query.Where(x => x.Category!.CategoryName == category);
            }

            // If no searchquery then skip this step, else check if string can be found in title or author.
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(x => x.Title.Contains(searchQuery) || x.Author.Contains(searchQuery));
            }

            // filter in ascending order by title - can be expanded by using a dropdown menu and sending in another string to replace Title.
            query = query.OrderBy(i => i.Title);
            #endregion

            #region PAGINATION
            var pagination = new Pagination
            {
                PageNumber = pageNumber,
                PageSize = pageSize, // pageSize could also be set from dropdownmenu where you could choose from a certain amount of courses to be displayed on the page.
                TotalItems = await query.CountAsync(),
                CurrentPage = pageNumber // is this right? It works but I could just use pageNumber instead.
            };

            // calculates the totalnumber of pages by dividing total courses by the amount of courses to be shown on the page.
            pagination.TotalPages = (int)Math.Ceiling(pagination.TotalItems / (double)pageSize);
           
            // Skip the appropriate number of courses to navigate to the desired page,
            // then take a number of courses equivalent to the page size, 
            // and asynchronously convert the result to a list, 
            // creating instances of courses using the CourseFactory.
            var returnCourses = CourseFactory.Create(await query.Skip((pageNumber -1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync());
            #endregion

            //returns a new courseresult only if pagination and returnCourses are not null.
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
