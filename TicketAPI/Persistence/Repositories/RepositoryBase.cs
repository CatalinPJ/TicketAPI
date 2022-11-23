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

        public void Create(T entity)
        {
            TicketContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            TicketContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            TicketContext.Set<T>().Remove(entity);
        }
    }
}