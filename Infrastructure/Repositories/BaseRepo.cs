using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Repositories
{
    public abstract class BaseRepo<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        private readonly TContext _context;

        protected BaseRepo(TContext context)
        {
            _context = context;
        }



        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

            return null!;

        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var result = await _context.Set<TEntity>().ToListAsync();
                if (result != null)
                {
                    return result;
                }
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

            return null!;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string str, string search)
        {
            try
            {
                var result = await _context.Set<TEntity>().ToListAsync();
                if (result != null)
                {
                    return result;
                }
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

            return null!;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllWithPredicateAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await _context.Set<TEntity>().Where(predicate).ToListAsync();
                if (result != null)
                {
                    return result;
                }
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

            return null!;
        }

        public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
                if (result != null)
                {
                    return result;
                }
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

            return null!;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity existingEntity, TEntity updatedEntity)
        {
            try
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return updatedEntity;
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

            return null!;
        }

        public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> predicate, TEntity entity)
        {
            try
            {
                var entityToUpdate = await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync(predicate);
                if (entityToUpdate != null)
                {
                    _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();
                    return entityToUpdate;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR :: " + ex.Message);
            }

            return null!;
        }

        public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var entititesToDelete = await _context.Set<TEntity>().Where(predicate).ToListAsync();

                if (entititesToDelete.Any())
                {
                    _context.RemoveRange(entititesToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

            return false;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                _context.RemoveRange(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

            return false;
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                var result = await _context.Set<TEntity>().AnyAsync(predicate);
                return result;
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }

            return false;
        }
    }
}
