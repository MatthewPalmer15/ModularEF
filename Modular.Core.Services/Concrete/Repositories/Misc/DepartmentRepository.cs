using Modular.Core.Models.Location;
using Modular.Core.Models.Misc;
using Modular.Core.Services.Repositories.Abstract.Misc;
using Newtonsoft.Json;

namespace Modular.Core.Services.Repositories.Concrete.Misc
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

        public Department? Get(Guid id)
        {
            return _context.Departments.Where(e => e.Id.Equals(id)).SingleOrDefault();
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
        }

        public void Update(Department department)
        {
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

        public string SerializeToJson(Department department)
        {
            return JsonConvert.SerializeObject(department, Formatting.Indented);
        }

        public Department? DeserializeFromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Department>(json);
            }
            catch
            {
                return null;
            }
        }

        #endregion


    }
}
