namespace Modular.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {

        IQueryable<T> All();

        T? Get(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<bool> SaveAsync();



    }
}
