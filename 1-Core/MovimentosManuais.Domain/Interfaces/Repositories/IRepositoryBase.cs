using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovimentosManuais.Domain
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetByWhere(Expression<Func<T, bool>> where);
        void UpdateItem(T entity);
        void InsertItem(T entity);
        void DeleteItem(T entity);
        Task SaveChangesAsync();
    }
}