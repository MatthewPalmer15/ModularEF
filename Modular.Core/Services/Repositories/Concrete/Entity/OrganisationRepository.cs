using Modular.Core.Interfaces;
using Modular.Core.Services.Abstract.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Models.Entity
{
    public class OrganisationRepository : IOrganisationRepository
    {

        #region "  Constructors  "

        public OrganisationRepository(ModularDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDBContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Organisation> All()
        {
            var query = from organisation in _context.Organisations select organisation;
            return query;
        }

        public void Add(Organisation organisation)
        {
            _context.Organisations.Add(organisation);
        }

        public void Update(Organisation organisation)
        {
            organisation.Update();
            _context.Organisations.Update(organisation);
        }

        public void Delete(Organisation organisation)
        {
            _context.Organisations.Remove(organisation);
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

