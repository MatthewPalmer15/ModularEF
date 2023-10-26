﻿using Modular.Core.Interfaces;
using Modular.Core.Models.Audit;
using Modular.Core.Models.Misc;
using Modular.Core.Services.Repositories.Abstract.Misc;

namespace Modular.Core.Services.Repositories.Concrete
{
    public class DepartmentRespository : IDepartmentRepository
    {

        #region "  Constructors  "

        public DepartmentRespository(ModularDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDbContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Department> All()
        {
            var query = from department in _context.Departments select department;
            return query;
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
        }

        public void Update(Department department)
        {
            department.Update();
            _context.Departments.Update(department);
        }

        public void Delete(Department department)
        {
            _context.Departments.Remove(department);
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