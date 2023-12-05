using Microsoft.EntityFrameworkCore;
using Modular.Core.Entities;
using Modular.Core.Services.Repositories.Abstract;
using Newtonsoft.Json;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class ContactRepository : IContactRepository
    {

        #region "  Constructors  "

        public ContactRepository(ModularDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDbContext _context;

        #endregion

        #region "  Properties  "

        public bool isModified => _context.ChangeTracker.HasChanges();

        #endregion

        #region "  Methods  "

        public IQueryable<Contact> All()
        {
            var query = from contact in _context.Contacts select contact;
            return query;
        }

        public Contact? Get(Guid Id)
        {
            IQueryable<Contact> query = this.All();
            query = query.Where(e => e.Id.Equals(Id));
            return query.Count() > 0 ? query.Take(1).SingleOrDefault() : null;
        }

        public List<Contact> Search(string searchTerm)
        {
            var contacts = All();
            contacts = contacts.Where(x => EF.Functions.Like(searchTerm, x.Forename) || EF.Functions.Like(searchTerm, x.Surname));
            return contacts.ToList();
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(contact);
        }

        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public string SerializeToJson(Contact contact)
        {
            return JsonConvert.SerializeObject(contact, Formatting.Indented);
        }

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

        #endregion

    }
}

