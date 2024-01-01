using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;
using Modular.Core.Entities.Abstract;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface IScheduledTaskRepository : IDisposable
    {

        // Properties
        public int Count { get; }

        public IEntityType EntityType { get; }

        public DbSet<ScheduledTask> DbSet { get; }

        // Methods

        public ScheduledTask New();

        public ScheduledTask New(string jobId, IScheduledTask.StatusType status);

        public IQueryable<ScheduledTask> GetAll();

        public ScheduledTask? Get(string jobId);

        public bool Exists(string jobId);

        public List<ScheduledTask> Search(string? searchTerm = null);

        public List<ScheduledTask> Search(Func<ScheduledTask, bool> predicate);

        public void Add(ScheduledTask entity);

        public Task AddAsync(ScheduledTask entity);

        public void AddRange(IList<ScheduledTask> entities);

        public Task AddRangeAsync(IList<ScheduledTask> entities);

        public void Update(ScheduledTask entity);

        public void UpdateRange(IList<ScheduledTask> entities);

        public void Delete(ScheduledTask entity);

        public void DeleteRange(IList<ScheduledTask> entities);

        public int SaveChanges();

        public Task<int> SaveChangesAsync();

        public string SerializeToJson(ScheduledTask entity);

        public string SerializeListToJson(IList<ScheduledTask> entities);

        public ScheduledTask? DeserializeFromJson(string json);

        public List<ScheduledTask>? DeserializeListFromJson(string json);


    }
}
