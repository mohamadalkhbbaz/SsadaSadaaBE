using System.Linq.Expressions;

namespace RepoPattern.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        List<T> GetAll(string[] includes);
        List<T> GetAll(Expression<Func<T, bool>> predicate, string[] includes, int take, int skip);
        List<T> GetAll(Expression<Func<T, bool>> predicate = null, string[] includes = null, int take = 0, int skip = 0, Expression<Func<T, object>> orderBy = null, string orderByDirection = Consts.OrderBy.Ascending);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void SaveChanges();
        List<T> Where(Expression<Func<T, bool>> predicate);
    }
}
