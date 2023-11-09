﻿using Modular.Core.Services.Repositories.Abstract.Entity;
using Modular.Core.Models.Entity;
using Newtonsoft.Json;

namespace Modular.Core.Services.Repositories.Concrete.Entity
{
    public class OrganisationRepository : IOrganisationRepository
    {

        #region "  Constructors  "

        public OrganisationRepository(ModularDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Organisation> All()
        {
            var query = from organisation in _context.Organisations select organisation;
            return query;
        }

        public Organisation? Get(Guid id)
        {
            return _context.Organisations.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        public void Add(Organisation organisation)
        {
            _context.Organisations.Add(organisation);
        }

        public void Update(Organisation organisation)
        {
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

        public string SerializeToJson(Organisation organisation)
        {
            return JsonConvert.SerializeObject(organisation, Formatting.Indented);
        }

        public Organisation? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Organisation>(json);
            }
            catch
            {
                return null;
            }
        }
        #endregion

    }
}

