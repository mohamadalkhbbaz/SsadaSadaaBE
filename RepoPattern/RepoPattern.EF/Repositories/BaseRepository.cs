using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RepoPattern.Core;
using RepoPattern.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<T> GetAll() => _context.Set<T>().ToList();

        public List<T> GetAll(string[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
                query = query.Include(include);

            return query.ToList();
        }

        public T GetById(int id) => _context.Set<T>().Find(id);

        public void Create(T entity)
        {
            _context.Add(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(GetById(id));
            SaveChanges();
        }

        public void SaveChanges() => _context.SaveChanges();

        public List<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate = null, string[] includes = null, int skip = 0, int take = 0)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
                query = query.Where(predicate);

            query = query.Skip(skip).Take(take);

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate, string[] includes, int take, int skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
                query = query.Where(predicate);

            query = query.Skip(skip).Take(take);

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

           if (orderBy != null)
            {
                if (orderByDirection == Consts.OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }
    }
}
