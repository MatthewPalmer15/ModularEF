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
    public class CountryRepository : ICountryRepository
    {

        private readonly IDbContext _context;

        private readonly IValidator<Country> _validator;

        public CountryRepository(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = new CountryValidator();
        }

        public CountryRepository(IDbContext context, IValidator<Country> validator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Total number of countries.
        /// </summary>
        public int Count
        {
            get
            {
                return _context.Countries.Count();
            }
        }

        public IEntityType EntityType
        {
            get
            {
                return _context.Countries.EntityType;
            }
        }

        public DbSet<Country> DbSet
        {
            get
            {
                return _context.Countries;
            }
        }

        /// <summary>
        /// Creates a new country. This does not save to the database.
        /// </summary>
        /// <returns></returns>
        public Country New()
        {
            return new Country();
        }

        /// <summary>
        /// Creates a new country. This does not save to the database.
        /// </summary>
        /// <returns></returns>
        public Country New(string name, string description, string code)
        {
            return new Country()
            {
                Name = name,
                Description = description,
                Code = code
            };
        }

        /// <summary>
        /// Validates a country synchronously.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public ModelResult Validate(Country country)
        {
            var result = _validator.Validate(country);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors);
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates a country asynchronously.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateAsync(Country country)
        {
            var result = await _validator.ValidateAsync(country);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors);
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple countries synchronously.
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public ModelResult ValidateRange(IList<Country> countries)
        {
            foreach (var country in countries)
            {
                var result = _validator.Validate(country);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors);
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple countries asynchronously.
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateRangeAsync(IList<Country> countries)
        {
            foreach (var country in countries)
            {
                var result = await _validator.ValidateAsync(country);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors);
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Country> GetAll()
        {
            var query = from country in _context.Countries select country;
            return query;
        }

        /// <summary>
        /// Gets country based on the Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Country? Get(Guid id)
        {
            return _context.Countries.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        /// <summary>
        /// Search all countries by the 'Name' value.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Country> Search(string? searchTerm = null)
        {
            var countries = this.GetAll();
            if (searchTerm != null)
            {
                countries = countries.Where(x => EF.Functions.Like(searchTerm, x.Name));
            }

            return countries.ToList();
        }

        /// <summary>
        /// Search all countries using a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Country> Search(Func<Country, bool> predicate)
        {
            IQueryable<Country> countries = this.GetAll();
            countries = countries.Where(predicate).AsQueryable();
            return countries.ToList();
        }

        /// <summary>
        /// Adds a country synchronously.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public ModelResult Add(Country country)
        {
            var result = _validator.Validate(country);
            if (result.IsValid)
            {
                _context.Countries.Add(country);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }

        }

        /// <summary>
        /// Adds a country asynchronously.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddAsync(Country country)
        {
            var result = await _validator.ValidateAsync(country);
            if (result.IsValid)
            {
                await _context.Countries.AddAsync(country);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }
        }

        /// <summary>
        /// Adds multiple countries synchronously. If any validation fails, none of the countries will be added.
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public ModelResult AddRange(IList<Country> countries)
        {
            foreach (var country in countries)
            {
                var result = _validator.Validate(country);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Countries.AddRange(countries);
            return ModelResult.Success();
        }

        /// <summary>
        /// Adds multiple countries asynchronously. If any validation fails, none of the countries will be added.
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddRangeAsync(IList<Country> countries)
        {
            foreach (var country in countries)
            {
                var result = await _validator.ValidateAsync(country);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            await _context.Countries.AddRangeAsync(countries);
            return ModelResult.Success();
        }

        /// <summary>
        /// Updates an existing country.
        /// </summary>
        /// <param name="country"></param>
        public ModelResult Update(Country country)
        {
            var result = _validator.Validate(country);
            if (result.IsValid)
            {
                _context.Countries.Update(country);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }
        }

        /// <summary>
        /// Updates multiple countries. If any validation fails, none of the countries will be added.
        /// </summary>
        /// <param name="countries"></param>
        public ModelResult UpdateRange(IList<Country> countries)
        {
            foreach (var country in countries)
            {
                var result = _validator.Validate(country);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Countries.UpdateRange(countries);
            return ModelResult.Success();
        }

        /// <summary>
        /// Deletes a country.
        /// </summary>
        /// <param name="country"></param>
        public void Delete(Country country)
        {
            _context.Countries.Remove(country);
        }

        /// <summary>
        /// Deletes multiple countries.
        /// </summary>
        /// <param name="countries"></param>
        public void DeleteRange(IList<Country> countries)
        {
            _context.Countries.RemoveRange(countries);
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
        /// Serializes country into JSON format.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public string SerializeToJson(Country country)
        {
            return JsonConvert.SerializeObject(country, Formatting.Indented);
        }

        /// <summary>
        /// Serializes countries into JSON format.
        /// </summary>
        /// <param name="countries"></param>
        /// <returns></returns>
        public string SerializeListToJson(IList<Country> countries)
        {
            return JsonConvert.SerializeObject(countries, Formatting.Indented);
        }

        /// <summary>
        /// Deserializes JSON into countries object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Country? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Country>(json);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializes JSON into countries object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public List<Country>? DeserializeListFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Country>>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}
