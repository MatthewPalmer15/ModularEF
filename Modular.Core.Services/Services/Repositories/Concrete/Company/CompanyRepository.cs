using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Modular.Core.Entities.Concrete;
using Modular.Core.Helpers;
using Modular.Core.Interfaces;
using Modular.Core.Services.Repositories.Abstract;
using Modular.Core.Services.Validation;
using Newtonsoft.Json;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly IDbContext _context;

        private readonly IValidator<Company> _validator;

        public CompanyRepository(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = new CompanyValidator();
        }

        public CompanyRepository(IDbContext context, IValidator<Company> validator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Total number of companies.
        /// </summary>
        public int Count
        {
            get
            {
                return _context.Companies.Count();
            }
        }

        public IEntityType EntityType
        {
            get
            {
                return _context.Companies.EntityType;
            }
        }

        public DbSet<Company> DbSet
        {
            get
            {
                return _context.Companies;
            }
        }

        /// <summary>
        /// Creates a new company. This does not save to the database.
        /// </summary>
        /// <returns></returns>
        public Company New()
        {
            return new Company();
        }

        /// <summary>
        /// Validates a company synchronously.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public ModelResult Validate(Company company)
        {
            var result = _validator.Validate(company);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates a company asynchronously.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateAsync(Company company)
        {
            var result = await _validator.ValidateAsync(company);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple companies synchronously.
        /// </summary>
        /// <param name="companies"></param>
        /// <returns></returns>
        public ModelResult ValidateRange(IList<Company> companies)
        {
            foreach (var company in companies)
            {
                var result = _validator.Validate(company);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors);
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple companies asynchronously.
        /// </summary>
        /// <param name="companies"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateRangeAsync(IList<Company> companies)
        {
            foreach (var company in companies)
            {
                var result = await _validator.ValidateAsync(company);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors);
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Gets all companies.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Company> GetAll()
        {
            var query = from company in _context.Companies select company;
            return query;
        }

        /// <summary>
        /// Gets company based on the Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Company? Get(Guid id)
        {
            return _context.Companies.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        /// <summary>
        /// Search all companies by the 'Name' value.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Company> Search(string? searchTerm = null)
        {
            var companies = this.GetAll();
            if (searchTerm != null)
            {
                companies = companies.Where(x => EF.Functions.Like(searchTerm, x.Name));
            }

            return companies.ToList();
        }

        /// <summary>
        /// Search all countries using a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Company> Search(Func<Company, bool> predicate)
        {
            IQueryable<Company> companies = this.GetAll();
            companies = companies.Where(predicate).AsQueryable();
            return companies.ToList();
        }

        /// <summary>
        /// Adds a company synchronously.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public ModelResult Add(Company company)
        {
            var result = _validator.Validate(company);
            if (result.IsValid)
            {
                _context.Companies.Add(company);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors);
            }
        }

        /// <summary>
        /// Adds a company asynchronously.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddAsync(Company company)
        {
            var result = await _validator.ValidateAsync(company);
            if (result.IsValid)
            {
                await _context.Companies.AddAsync(company);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors);
            }
        }

        /// <summary>
        /// Adds multiple companies synchronously. If any validation fails, none of the companies will be added.
        /// </summary>
        /// <param name="companies"></param>
        /// <returns></returns>
        public ModelResult AddRange(IList<Company> companies)
        {
            foreach (var company in companies)
            {
                var result = _validator.Validate(company);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Companies.AddRange(companies);
            return ModelResult.Success();
        }

        /// <summary>
        /// Adds multiple companies asynchronously. If any validation fails, none of the companies will be added.
        /// </summary>
        /// <param name="companies"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddRangeAsync(IList<Company> companies)
        {
            foreach (var company in companies)
            {
                var result = await _validator.ValidateAsync(company);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            await _context.Companies.AddRangeAsync(companies);
            return ModelResult.Success();
        }

        /// <summary>
        /// Updates an existing company.
        /// </summary>
        /// <param name="company"></param>
        public ModelResult Update(Company company)
        {
            var result = _validator.Validate(company);
            if (result.IsValid)
            {
                _context.Companies.Update(company);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }
        }

        /// <summary>
        /// Updates multiple companies. If any validation fails, none of the companies will be added.
        /// </summary>
        /// <param name="companies"></param>
        public ModelResult UpdateRange(IList<Company> companies)
        {
            foreach (var company in companies)
            {
                var result = _validator.Validate(company);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Companies.UpdateRange(companies);
            return ModelResult.Success();
        }

        /// <summary>
        /// Deletes a company.
        /// </summary>
        /// <param name="company"></param>
        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
        }

        /// <summary>
        /// Deletes multiple companies.
        /// </summary>
        /// <param name="companies"></param>
        public void DeleteRange(IList<Company> companies)
        {
            _context.Companies.RemoveRange(companies);
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
        /// Serializes company into JSON format.
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public string SerializeToJson(Company company)
        {
            return JsonConvert.SerializeObject(company, Formatting.Indented);
        }

        /// <summary>
        /// Serializes companies into JSON format.
        /// </summary>
        /// <param name="companies"></param>
        /// <returns></returns>
        public string SerializeListToJson(IList<Company> companies)
        {
            return JsonConvert.SerializeObject(companies, Formatting.Indented);
        }

        /// <summary>
        /// Deserializes JSON into company object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Company? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Company>(json);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializes JSON into company object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public List<Company>? DeserializeListFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Company>>(json);
            }
            catch
            {
                return null;
            }
        }


    }
}

