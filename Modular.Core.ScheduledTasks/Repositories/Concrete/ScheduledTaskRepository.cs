using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Modular.Core.Entities.Abstract;
using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;
using Modular.Core.Services.Repositories.Abstract;
using Modular.Core.Services.Validation;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Modular.Core.Services.Repositories.Concrete
{
    internal class ScheduledTaskRepository : IScheduledTaskRepository
    {

        private readonly ModularScheduledTaskDbContext _context;

        public ScheduledTaskRepository(ModularScheduledTaskDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Total number of Tasks
        /// </summary>
        public int Count
        {
            get
            {
                return _context.ScheduledTasks.Count();
            }
        }

        public IEntityType EntityType
        {
            get
            {
                return _context.ScheduledTasks.EntityType;
            }
        }

        public DbSet<ScheduledTask> DbSet
        {
            get
            {
                return _context.ScheduledTasks;
            }
        }

        /// <summary>
        /// Creates a new task. This does not save to the database.
        /// </summary>
        /// <returns></returns>
        public ScheduledTask New()
        {
            return new ScheduledTask();
        }

        /// <summary>
        /// Creates a new task. This does not save to the database.
        /// </summary>
        /// <returns></returns>
        public ScheduledTask New(string jobId, IScheduledTask.StatusType status)
        {
            return new ScheduledTask(jobId, status);
        }

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <returns></returns>
        public IQueryable<ScheduledTask> GetAll()
        {
            var query = from task in DbSet select task;
            return query;
        }

        /// <summary>
        /// Gets task based on its job id.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public ScheduledTask? Get(string jobId)
        {
            return DbSet.Where(e => e.JobId.Equals(jobId)).SingleOrDefault();
        }

        public bool Exists(string jobId)
        {
            return DbSet.Where(e => e.JobId.Equals(jobId)).Count() > 0;
        }

        /// <summary>
        /// Search all tasks by the 'Job Id' value.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<ScheduledTask> Search(string? searchTerm = null)
        {
            var tasks = this.GetAll();
            if (searchTerm != null)
            {
                tasks = tasks.Where(x => EF.Functions.Like(searchTerm, x.JobId) || EF.Functions.Like(searchTerm, x.ParentJobId));
            }

            return tasks.ToList();
        }

        /// <summary>
        /// Search all tasks using a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<ScheduledTask> Search(Func<ScheduledTask, bool> predicate)
        {
            IQueryable<ScheduledTask> tasks = this.GetAll();
            tasks = tasks.Where(predicate).AsQueryable();
            return tasks.ToList();
        }

        /// <summary>
        /// Adds a task synchronously.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public void Add(ScheduledTask task)
        {
            DbSet.Add(task);
        }

        /// <summary>
        /// Adds a task asynchronously.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public async Task AddAsync(ScheduledTask task)
        {
            await DbSet.AddAsync(task);
        }

        /// <summary>
        /// Adds multiple tasks synchronously.
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public void AddRange(IList<ScheduledTask> tasks)
        {
            DbSet.AddRange(tasks);
        }

        /// <summary>
        /// Adds multiple tasks synchronously.
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(IList<ScheduledTask> tasks)
        {
            await DbSet.AddRangeAsync(tasks);
        }

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="task"></param>
        public void Update(ScheduledTask task)
        {
            DbSet.Update(task);
        }

        /// <summary>
        /// Updates multiple tasks.
        /// </summary>
        /// <param name="task"></param>
        public void UpdateRange(IList<ScheduledTask> tasks)
        {
            DbSet.UpdateRange(tasks);
        }

        /// <summary>
        /// Deletes a task.
        /// </summary>
        /// <param name="task"></param>
        public void Delete(ScheduledTask task)
        {
            DbSet.Remove(task);
        }

        /// <summary>
        /// Deletes multiple tasks.
        /// </summary>
        /// <param name="tasks"></param>
        public void DeleteRange(IList<ScheduledTask> tasks)
        {
            DbSet.RemoveRange(tasks);
        }

        /// <summary>
        /// Saves changes to the database synchronously.
        /// </summary>
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        /// Saves changes to the database asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Disposes the database context.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the database context.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        /// <summary>
        /// Serializes task into JSON format.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public string SerializeToJson(ScheduledTask task)
        {
            return JsonConvert.SerializeObject(task, Formatting.Indented);
        }

        /// <summary>
        /// Serializes tasks into JSON format.
        /// </summary>
        /// <param name="companies"></param>
        /// <returns></returns>
        public string SerializeListToJson(IList<ScheduledTask> tasks)
        {
            return JsonConvert.SerializeObject(tasks, Formatting.Indented);
        }

        /// <summary>
        /// Deserializes JSON into task object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public ScheduledTask? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ScheduledTask>(json);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializes JSON into task object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public List<ScheduledTask>? DeserializeListFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ScheduledTask>>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}

