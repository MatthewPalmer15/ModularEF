using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Modular.Core.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {

        // Properties
        public int Count { get; }

        public IEntityType EntityType { get; }

        public DbSet<TModel> DbSet { get; }

        // Methods

        public TModel New();

        public ModelResult Validate(TModel entity);

        public Task<ModelResult> ValidateAsync(TModel entity);

        public ModelResult ValidateRange(IList<TModel> entities);

        public Task<ModelResult> ValidateRangeAsync(IList<TModel> entities);

        public IQueryable<TModel> GetAll();

        public TModel? Get(Guid id);

        public List<TModel> Search(string? searchTerm = null);

        public List<TModel> Search(Func<TModel, bool> predicate);

        public ModelResult Add(TModel entity);

        public Task<ModelResult> AddAsync(TModel entity);

        public ModelResult AddRange(IList<TModel> entities);

        public Task<ModelResult> AddRangeAsync(IList<TModel> entities);

        public ModelResult Update(TModel entity);

        public ModelResult UpdateRange(IList<TModel> entities);

        public void Delete(TModel entity);

        public void DeleteRange(IList<TModel> entities);

        public int SaveChanges();

        public Task<int> SaveChangesAsync();

        public string SerializeToJson(TModel entity);

        public string SerializeListToJson(IList<TModel> entities);

        public TModel? DeserializeFromJson(string json);

        public List<TModel>? DeserializeListFromJson(string json);

    }
}
