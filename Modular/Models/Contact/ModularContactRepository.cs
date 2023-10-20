using Modular.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Entity
{
    public class ContactRepository : IModularRepository<Contact>, IDisposable
    {

        #region "  Constructors  "

        public ContactRepository(ModularDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDBContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Contact> All()
        {
            var query = from contact in _context.Contacts select contact;
            return query;
        }

        
        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            contact.Update();
            _context.Contacts.Update(contact);
        }

        public void Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
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

