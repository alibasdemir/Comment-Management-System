using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence
{
    public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
        where TContext : DbContext
        where TEntity : Entity
    {
        private readonly TContext Context;
        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }
        public IQueryable<TEntity> Query() => Context.Set<TEntity>();
        public async Task AddAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            entity.CreatedDate = DateTime.Now;
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedDate = DateTime.Now;
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();
            if (include != null)
            {
                data = include(data);
            }

            return await data.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();
            if (predicate != null)
            {
                data = data.Where(predicate);
            }

            if (include != null)
            {
                data = include(data);
            }

            return await data.ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            entity.UpdatedDate = DateTime.Now;
            await Context.SaveChangesAsync();
        }
    }
}
