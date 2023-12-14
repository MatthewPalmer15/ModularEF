using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Modular.Core.Helpers;

namespace Modular.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {

        // Properties
        public int Count { get; }

        public IEntityType EntityType { get; }

        public DbSet<T> DbSet { get; }

        // Methods

        public ModelResult Validate(T entity);

        public Task<ModelResult> ValidateAsync(T entity);

        public ModelResult ValidateRange(IList<T> entities);

        public Task<ModelResult> ValidateRangeAsync(IList<T> entities);

        public IQueryable<T> GetAll();

        public T? Get(Guid id);

        public List<T> Search(string? searchTerm = null);

        public List<T> Search(Func<T, bool> predicate);

        public ModelResult Add(T entity);

        public Task<ModelResult> AddAsync(T entity);

        public ModelResult AddRange(IList<T> entities);

        public Task<ModelResult> AddRangeAsync(IList<T> entities);

        public ModelResult Update(T entity);

        public ModelResult UpdateRange(IList<T> entities);

        public void Delete(T entity);

        public void DeleteRange(IList<T> entities);

        public int SaveChanges();

        public Task<int> SaveChangesAsync();

        public string SerializeToJson(T entity);

        public string SerializeListToJson(IList<T> entities);

        public T? DeserializeFromJson(string json);

        public List<T>? DeserializeListFromJson(string json);

    }
}
