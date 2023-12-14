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
    public class ContactRepository : IContactRepository
    {

        private readonly IDbContext _context;

        private readonly IValidator<Contact> _validator;

        public ContactRepository(IDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = new ContactValidator();
        }

        public ContactRepository(IDbContext context, IValidator<Contact> validator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <summary>
        /// Total number of contacts.
        /// </summary>
        public int Count
        {
            get
            {
                return _context.Contacts.Count();
            }
        }

        public IEntityType EntityType
        {
            get
            {
                return _context.Contacts.EntityType;
            }
        }

        /// <summary>
        /// Validates a contact synchronously.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public ModelResult Validate(Contact contact)
        {
            var result = _validator.Validate(contact);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates a contact asynchronously.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateAsync(Contact contact)
        {
            var result = await _validator.ValidateAsync(contact);
            if (!result.IsValid)
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple contacts synchronously.
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public ModelResult ValidateRange(IList<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                var result = _validator.Validate(contact);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Validates multiple contacts asynchronously.
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public async Task<ModelResult> ValidateRangeAsync(IList<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                var result = await _validator.ValidateAsync(contact);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            return ModelResult.Success();
        }

        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Contact> GetAll()
        {
            var query = from contact in _context.Contacts select contact;
            return query;
        }

        /// <summary>
        /// Gets contact based on the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact? Get(Guid id)
        {
            return _context.Contacts.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        /// <summary>
        /// Search all contacts by the 'Forename' and 'Surname' value.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Contact> Search(string searchTerm)
        {
            var contacts = this.GetAll();
            contacts = contacts.Where(x => EF.Functions.Like(searchTerm, x.Forename) || EF.Functions.Like(searchTerm, x.Surname));
            return contacts.ToList();
        }

        /// <summary>
        /// Adds a contact synchronously.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public ModelResult Add(Contact contact)
        {
            var result = _validator.Validate(contact);
            if (result.IsValid)
            {
                _context.Contacts.Add(contact);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }

        }

        /// <summary>
        /// Adds a contact asynchronously.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddAsync(Contact contact)
        {
            var result = await _validator.ValidateAsync(contact);
            if (result.IsValid)
            {
                await _context.Contacts.AddAsync(contact);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }
        }

        /// <summary>
        /// Adds multiple contacts synchronously. If any validation fails, none of the contacts will be added.
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public ModelResult AddRange(IList<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                var result = _validator.Validate(contact);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Contacts.AddRange(contacts);
            return ModelResult.Success();
        }

        /// <summary>
        /// Adds multiple contacts asynchronously. If any validation fails, none of the contacts will be added.
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public async Task<ModelResult> AddRangeAsync(IList<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                var result = await _validator.ValidateAsync(contact);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            await _context.Contacts.AddRangeAsync(contacts);
            return ModelResult.Success();
        }

        /// <summary>
        /// Updates an existing contact.
        /// </summary>
        /// <param name="contact"></param>
        public ModelResult Update(Contact contact)
        {
            var result = _validator.Validate(contact);
            if (result.IsValid)
            {
                _context.Contacts.Update(contact);
                return ModelResult.Success();
            }
            else
            {
                return ModelResult.Failed(result.Errors.ToArray());
            }
        }

        /// <summary>
        /// Updates multiple contacts. If any validation fails, none of the contacts will be added.
        /// </summary>
        /// <param name="contacts"></param>
        public ModelResult UpdateRange(IList<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                var result = _validator.Validate(contact);
                if (!result.IsValid)
                {
                    return ModelResult.Failed(result.Errors.ToArray());
                }
            }

            _context.Contacts.UpdateRange(contacts);
            return ModelResult.Success();
        }

        /// <summary>
        /// Deletes a contact.
        /// </summary>
        /// <param name="contact"></param>
        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        /// <summary>
        /// Deletes multiple contacts.
        /// </summary>
        /// <param name="contacts"></param>
        public void DeleteRange(IList<Contact> contacts)
        {
            _context.Contacts.RemoveRange(contacts);
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
        /// Serializes contact into JSON format.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public string SerializeToJson(Contact contact)
        {
            return JsonConvert.SerializeObject(contact, Formatting.Indented);
        }

        /// <summary>
        /// Serializes contacts into JSON format.
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        public string SerializeListToJson(IList<Contact> contacts)
        {
            return JsonConvert.SerializeObject(contacts, Formatting.Indented);
        }

        /// <summary>
        /// Deserializes JSON into contact object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public Contact? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Contact>(json);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deserializes JSON into contacts object. This will return null if JSON cannot be mapped to object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public List<Contact>? DeserializeListFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Contact>>(json);
            }
            catch
            {
                return null;
            }
        }

    }
}

