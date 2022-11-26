using System.Linq.Expressions;
using TicketAPI.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace TicketAPI.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TicketContext TicketContext { get; set; }

        protected RepositoryBase(TicketContext ticketContext)
        {
            TicketContext = ticketContext;
        }

        public virtual IQueryable<T> GetAll()
        {
            return TicketContext.Set<T>().AsNoTracking();
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return TicketContext.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return TicketContext.Set<T>().FirstOrDefault(expression);
        }
        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return TicketContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public void Create(T entity)
        {
            TicketContext.Set<T>().Add(entity);
            TicketContext.SaveChanges();
        }

        public async Task CreateAsync(T entity)
        {
            TicketContext.Set<T>().Add(entity);
            await TicketContext.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            TicketContext.Set<T>().Update(entity);
            TicketContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            TicketContext.Set<T>().Update(entity);
            await TicketContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            TicketContext.Set<T>().Remove(entity);
            TicketContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            TicketContext.Set<T>().Remove(entity);
            await TicketContext.SaveChangesAsync();
        }
    }
}