using Modular.Core.Services.Repositories.Abstract.Entity;
using Modular.Core.Models.Entity;

namespace Modular.Core.Services.Repositories.Concrete.Entity
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

        #region "  CRUD Methods  "

        public IQueryable<Contact> All()
        {
            var query = from contact in _context.Contacts select contact;
            return query;
        }

        public Contact? Get(Guid id)
        {
            return _context.Contacts.Where(e => e.Id.Equals(id)).SingleOrDefault();
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

        #endregion

    }
}

