﻿using Modular.Core.Models.Misc;
using Modular.Core.Services.Repositories.Abstract.Misc;

namespace Modular.Core.Services.Repositories.Concrete.Misc
{
    public class OccupationRespository : IOccupationRepository
    {

        #region "  Constructors  "

        public OccupationRespository(ModularDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Occupation> All()
        {
            var query = from occupation in _context.Occupations select occupation;
            return query;
        }

        public Occupation? Get(Guid id)
        {
            return _context.Occupations.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        public void Add(Occupation occupation)
        {
            _context.Occupations.Add(occupation);
        }

        public void Update(Occupation occupation)
        {
            _context.Occupations.Update(occupation);
        }

        public void Delete(Occupation occupation)
        {
            _context.Occupations.Remove(occupation);
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