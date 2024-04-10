using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CourseService(CourseRepository repository)
{
    private readonly CourseRepository _repository = repository;

    /// <summary>
    /// Creates a course in the database.
    /// </summary>
    /// <param name="entity">The course to be created using CourseEntity.</param>
    /// <returns>The created CourseEntity.</returns>
    public async Task<CourseEntity> CreateCourseAsync(CourseEntity entity)
    {
        try
        {
            var existingCourse = await _repository.GetOneAsync(x => x.Title == entity.Title && x.Author == entity.Author);
            if (existingCourse == null)
            {
                var result = await _repository.CreateAsync(entity);
                if (result != null)
                {
                    return result;
                }
            }
            //return 409 conflict
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;

    }

    /// <summary>
    /// Gets on CourseEntity from database.
    /// </summary>
    /// <param name="Id">Id of the CourseEntity to get.</param>
    /// <returns>One CourseEntity.</returns>
    public async Task<CourseEntity> GetCourseAsync(string Id)
    {
        try
        {
            var existingCourse = await _repository.GetOneAsync(x => x.Id == Id);
            if (existingCourse != null)
            {
                return existingCourse;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;

    }

    /// <summary>
    /// Gets all Courses and filters them in the repository via an override.
    /// </summary>
    /// <param name="category">the category selecte to filter by.</param>
    /// <param name="searchQuery">The searchQuery from the search field.</param>
    /// <param name="pageNumber">the current pagenumber as decided by javascript or the repository.</param>
    /// <param name="pageSize">The number of items displayed per page.</param>
    /// <returns></returns>
    public async Task<CourseResult> GetAllCoursesAsync(string? category, string? searchQuery, int pageNumber, int pageSize)
    {
        try
        {
            var existingCourses = await _repository.GetAllAsync(category, searchQuery, pageNumber, pageSize);
            if (existingCourses != null && existingCourses.ReturnCourses.Count() >= 1)
            {
                return existingCourses;
            }           
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;

    }

    /// <summary>
    /// Updates one CourseEntity in the database.
    /// </summary>
    /// <param name="updatedEntity">The CourseEntity to be updated.</param>
    /// <returns>The updated CourseEntity.</returns>
    public async Task<CourseEntity> UpdateCourseAsync(CourseEntity updatedEntity) 
    {
        try
        {
            var existingCourse = await _repository.GetOneAsync(x => x.Id == updatedEntity.Id);
            if (existingCourse != null)
            {
                var result = await _repository.UpdateAsync(existingCourse, updatedEntity);
                if (result != null)
                {
                    return result;
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

    /// <summary>
    /// Deletes one CourseEntity from the database.
    /// </summary>
    /// <param name="Id">The Id of the CourseEntity to be deleted.</param>
    /// <returns>The deleted CourseEntity</returns>
    public async Task<CourseEntity> DeleteCourseAsync(string Id)
    {
        try
        {
            var existingCourse = await _repository.GetOneAsync(x => x.Id == Id);
            if (existingCourse != null)
            {
                var result = await _repository.DeleteAsync(existingCourse);
                if (result)
                {
                    return existingCourse;
                }
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;
    }

}
