using Infrastructure.Entity;
using Infrastructure.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CourseService(CourseRepository repository)
{
    private readonly CourseRepository _repository = repository;

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

    public async Task<IEnumerable<CourseEntity>> GetAllCoursesAsync()
    {
        try
        {
            var existingCourses = await _repository.GetAllAsync();
            if (existingCourses.Count() > 0)
            {
                return existingCourses;
            }           
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
        return null!;

    }

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

    public async Task<CourseEntity> DeleteCourseAsync(CourseEntity entity)
    {
        try
        {
            var existingCourse = await _repository.GetOneAsync(x => x.Id == entity.Id);
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
