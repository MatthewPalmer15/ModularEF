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
    public class InvoiceRepository : IInvoiceRepository
    {

        private readonly IDbContext _context;

        private readonly IValidator<Invoice> _validator;

        public InvoiceRepository(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public InvoiceRepository(IDbContext context, IValidator<Invoice> validator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Total number of invoices.
        /// </summary>
        public int Count
        {
            get
            {
                return _context.Invoices.Count();
            }
        }

        public IEntityType EntityType
        {
            get
            {
                return _context.Invoices.EntityType;
            }
        }

        public DbSet<Invoice> DbSet
        {
            get
            {
                return _context.Invoices;
            }
        }

        /// <summary>
        /// Creates a new invoice. This does not save to the database.
        /// </summary>
        /// <returns></returns>
        public Invoice New()
        {
            return new Invoice();
        }

        /// <summary>
        /// Validates a invoice synchronously.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public ModelResult Validate(Invoice invoice)
        {
            var result = _validator.Validate(invoice);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors);
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates a invoice asynchronously.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateAsync(Invoice invoice)
        {
            var result = await _validator.ValidateAsync(invoice);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors);
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple invoices synchronously.
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public ModelResult ValidateRange(IList<Invoice> invoices)
        {
            foreach (var invoice in invoices)
            {
                var result = _validator.Validate(invoice);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors);
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple invoices asynchronously.
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateRangeAsync(IList<Invoice> invoices)
        {
            foreach (var invoice in invoices)
            {
                var result = await _validator.ValidateAsync(invoice);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors);
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Gets all invoices.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Invoice> GetAll()
        {
            var query = from invoice in _context.Invoices select invoice;
            return query;
        }

        /// <summary>
        /// Gets invoice based on the Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Invoice? Get(Guid id)
        {
            return _context.Invoices.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        /// <summary>
        /// Search all invoices by the 'InvoiceNumber' value.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Invoice> Search(string? searchTerm = null)
        {
            var invoices = this.GetAll();
            if (searchTerm != null)
            {
                invoices = invoices.Where(x => EF.Functions.Like(searchTerm, x.InvoiceNumber.ToString()));
            }

            return invoices.ToList();
        }

        /// <summary>
        /// Search all invoices using a predicate.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<Invoice> Search(Func<Invoice, bool> predicate)
        {
            IQueryable<Invoice> invoices = this.GetAll();
            invoices = invoices.Where(predicate).AsQueryable();
            return invoices.ToList();
        }

        /// <summary>
        /// Adds a invoice synchronously.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public ModelResult Add(Invoice invoice)
        {
            var result = _validator.Validate(invoice);
            if (result.IsValid)
            {
                _context.Invoices.Add(invoice);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }

        }

        /// <summary>
        /// Adds a invoice asynchronously.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddAsync(Invoice invoice)
        {
            var result = await _validator.ValidateAsync(invoice);
            if (result.IsValid)
            {
                await _context.Invoices.AddAsync(invoice);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }
        }

        /// <summary>
        /// Adds multiple invoices synchronously. If any validation fails, none of the invoices will be added.
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public ModelResult AddRange(IList<Invoice> invoices)
        {
            foreach (var invoice in invoices)
            {
                var result = _validator.Validate(invoice);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Invoices.AddRange(invoices);
            return ModelResult.Success();
        }

        /// <summary>
        /// Adds multiple invoices asynchronously. If any validation fails, none of the invoices will be added.
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddRangeAsync(IList<Invoice> invoices)
        {
            foreach (var invoice in invoices)
            {
                var result = await _validator.ValidateAsync(invoice);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            await _context.Invoices.AddRangeAsync(invoices);
            return ModelResult.Success();
        }

        /// <summary>
        /// Updates an existing invoice.
        /// </summary>
        /// <param name="invoice"></param>
        public ModelResult Update(Invoice invoice)
        {
            var result = _validator.Validate(invoice);
            if (result.IsValid)
            {
                _context.Invoices.Update(invoice);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }
        }

        /// <summary>
        /// Updates multiple invoices. If any validation fails, none of the invoices will be added.
        /// </summary>
        /// <param name="invoices"></param>
        public ModelResult UpdateRange(IList<Invoice> invoices)
        {
            foreach (var invoice in invoices)
            {
                var result = _validator.Validate(invoice);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Invoices.UpdateRange(invoices);
            return ModelResult.Success();
        }

        /// <summary>
        /// Deletes a invoice.
        /// </summary>
        /// <param name="invoice"></param>
        public void Delete(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
        }

        /// <summary>
        /// Deletes multiple invoices.
        /// </summary>
        /// <param name="invoices"></param>
        public void DeleteRange(IList<Invoice> invoices)
        {
            _context.Invoices.RemoveRange(invoices);
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
        /// Serializes invoice into JSON format.
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public string SerializeToJson(Invoice invoice)
        {
            return JsonConvert.SerializeObject(invoice, Formatting.Indented);
        }

        /// <summary>
        /// Serializes invoices into JSON format.
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public string SerializeListToJson(IList<Invoice> invoices)
        {
            return JsonConvert.SerializeObject(invoices, Formatting.Indented);
        }

        /// <summary>
        /// Deserializes JSON into invoice object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Invoice? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Invoice>(json);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializes JSON into invoices object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public List<Invoice>? DeserializeListFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Invoice>>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}
