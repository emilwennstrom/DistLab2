using System.Linq.Expressions;

namespace DistLab2.Persistence.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        void Add(T item);
        void Remove(T item);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
