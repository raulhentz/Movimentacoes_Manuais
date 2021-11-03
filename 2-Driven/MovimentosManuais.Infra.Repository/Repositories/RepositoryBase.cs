using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovimentosManuais.Domain;
using MovimentosManuais.Infra.Repository.DataBaseConfig;

namespace MovimentosManuais.Infra.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public readonly MovimentacoesManuaisContext _context;
        protected DbSet<T> DbSet
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public RepositoryBase(MovimentacoesManuaisContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void InsertItem(T entity)
        {
            try
            {
                _context.Add<T>(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateItem(T entity)
        {
            try
            {
                _context.Update<T>(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteItem(T entity)
        {
            try
            {
                _context.Remove<T>(entity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                IQueryable<T> _query = DbSet;
                return _query.AsQueryable();                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetByWhere(Expression<Func<T, bool>> where)
        {
            try
            {
                return DbSet.Where(where);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}