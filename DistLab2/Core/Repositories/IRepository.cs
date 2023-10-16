using System.Linq.Expressions;

namespace DistLab2.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T item);
        void Remove(T item);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
