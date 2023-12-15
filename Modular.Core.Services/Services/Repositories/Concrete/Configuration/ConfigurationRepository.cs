using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Modular.Core.Entities;
using Modular.Core.Helpers;
using Modular.Core.Interfaces;
using Modular.Core.Services.Repositories.Abstract;
using Modular.Core.Services.Validation;
using Newtonsoft.Json;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class ConfigurationRepository : IConfigurationRepository
    {

        private readonly IDbContext _context;

        private readonly IValidator<Configuration> _validator;

        public ConfigurationRepository(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = new ConfigurationValidator(context);
        }

        public ConfigurationRepository(IDbContext context, IValidator<Configuration> validator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Total number of configurations.
        /// </summary>
        public int Count
        {
            get
            {
                return _context.Configurations.Count();
            }
        }

        public IEntityType EntityType
        {
            get
            {
                return _context.Configurations.EntityType;
            }
        }

        public DbSet<Configuration> DbSet
        {
            get
            {
                return _context.Configurations;
            }
        }

        /// <summary>
        /// Validates a configuration synchronously.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public ModelResult Validate(Configuration configuration)
        {
            var result = _validator.Validate(configuration);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors);
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates a configuration asynchronously.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateAsync(Configuration configuration)
        {
            var result = await _validator.ValidateAsync(configuration);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors);
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple configurations synchronously.
        /// </summary>
        /// <param name="configurations"></param>
        /// <returns></returns>
        public ModelResult ValidateRange(IList<Configuration> configurations)
        {
            foreach (var configuration in configurations)
            {
                var result = _validator.Validate(configuration);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors);
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple configurations asynchronously.
        /// </summary>
        /// <param name="configurations"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateRangeAsync(IList<Configuration> configurations)
        {
            foreach (var configuration in configurations)
            {
                var result = await _validator.ValidateAsync(configuration);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors);
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Gets all configurations.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Configuration> GetAll()
        {
            var query = from configuration in _context.Configurations select configuration;
            return query;
        }

        /// <summary>
        /// Gets configuration based on the Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Configuration? Get(Guid id)
        {
            return _context.Configurations.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        /// <summary>
        /// Gets value of configuration by the 'Key' value.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string? GetValue(string key)
        {
            var query = this.GetAll();
            query = query.Where(configuration => configuration.Key.Trim().Equals(key.Trim(), StringComparison.CurrentCultureIgnoreCase));

            Configuration? config = query.SingleOrDefault();
            if (config != null)
            {
                return config.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Search all configurations by the 'Key' value.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Configuration> Search(string? searchTerm = null)
        {
            var configurations = this.GetAll();
            if (searchTerm != null)
            {
                configurations = configurations.Where(x => EF.Functions.Like(searchTerm, x.Key));
            }

            return configurations.ToList();
        }

        /// <summary>
        /// Search all configurations using a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Configuration> Search(Func<Configuration, bool> predicate)
        {
            IQueryable<Configuration> configurations = this.GetAll();
            configurations = configurations.Where(predicate).AsQueryable();
            return configurations.ToList();
        }

        /// <summary>
        /// Adds a configuration synchronously.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public ModelResult Add(Configuration configuration)
        {
            var result = _validator.Validate(configuration);
            if (result.IsValid)
            {
                _context.Configurations.Add(configuration);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }

        }

        /// <summary>
        /// Adds a configuration asynchronously.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddAsync(Configuration configuration)
        {
            var result = await _validator.ValidateAsync(configuration);
            if (result.IsValid)
            {
                await _context.Configurations.AddAsync(configuration);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }
        }

        /// <summary>
        /// Adds multiple configurations synchronously. If any validation fails, none of the configurations will be added.
        /// </summary>
        /// <param name="configurations"></param>
        /// <returns></returns>
        public ModelResult AddRange(IList<Configuration> configurations)
        {
            foreach (var configuration in configurations)
            {
                var result = _validator.Validate(configuration);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Configurations.AddRange(configurations);
            return ModelResult.Success();
        }

        /// <summary>
        /// Adds multiple configurations asynchronously. If any validation fails, none of the configurations will be added.
        /// </summary>
        /// <param name="configurations"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddRangeAsync(IList<Configuration> configurations)
        {
            foreach (var configuration in configurations)
            {
                var result = await _validator.ValidateAsync(configuration);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            await _context.Configurations.AddRangeAsync(configurations);
            return ModelResult.Success();
        }

        /// <summary>
        /// Updates an existing configuration.
        /// </summary>
        /// <param name="configuration"></param>
        public ModelResult Update(Configuration configuration)
        {
            var result = _validator.Validate(configuration);
            if (result.IsValid)
            {
                _context.Configurations.Update(configuration);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }
        }

        /// <summary>
        /// Updates multiple configurations. If any validation fails, none of the configurations will be added.
        /// </summary>
        /// <param name="configurations"></param>
        public ModelResult UpdateRange(IList<Configuration> configurations)
        {
            foreach (var configuration in configurations)
            {
                var result = _validator.Validate(configuration);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Configurations.UpdateRange(configurations);
            return ModelResult.Success();
        }

        /// <summary>
        /// Deletes a configuration.
        /// </summary>
        /// <param name="configuration"></param>
        public void Delete(Configuration configuration)
        {
            _context.Configurations.Remove(configuration);
        }

        /// <summary>
        /// Deletes multiple configurations.
        /// </summary>
        /// <param name="configurations"></param>
        public void DeleteRange(IList<Configuration> configurations)
        {
            _context.Configurations.RemoveRange(configurations);
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
        /// Serializes configuration into JSON format.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public string SerializeToJson(Configuration configuration)
        {
            return JsonConvert.SerializeObject(configuration, Formatting.Indented);
        }

        /// <summary>
        /// Serializes configurations into JSON format.
        /// </summary>
        /// <param name="configurations"></param>
        /// <returns></returns>
        public string SerializeListToJson(IList<Configuration> configurations)
        {
            return JsonConvert.SerializeObject(configurations, Formatting.Indented);
        }

        /// <summary>
        /// Deserializes JSON into configuration object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Configuration? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Configuration>(json);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializes JSON into configuration object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public List<Configuration>? DeserializeListFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Configuration>>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}