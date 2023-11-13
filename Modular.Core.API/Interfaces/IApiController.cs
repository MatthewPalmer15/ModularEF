using System.Linq.Expressions;

namespace Modular.Core.API.Interfaces
{
    public interface IApiController<T> where T : class
    {

        T? Get(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);

    }
}