using Microsoft.Extensions.Configuration;
using Modular.Core.Entity;
using Modular.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modular.Core.Config
{
    public class ConfigurationRepository : IConfigurationRepository, IModularRepository<Configuration>, IDisposable
    {

        #region "  Constructors  "

        public ConfigurationRepository(ModularDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region "  Variables  "

        private readonly ModularDBContext _context;

        #endregion

        #region "  Methods  "

        public IQueryable<Configuration> All()
        {
            var query = from configuration in _context.Configurations select configuration;
            return query;
        }

        public string GetValue(string key)
        {
            var query = All();
            query = query.Where(configuration => configuration.Key.Trim().ToUpper() == key.Trim().ToUpper());
            
            Configuration? config = query.SingleOrDefault();

            return config != null ? config.Value : string.Empty;
        }


        public void Add(Configuration configuration)
        {
            _context.Configurations.Add(configuration);
        }

        public void Update(Configuration configuration)
        {
            configuration.Update();
            _context.Configurations.Update(configuration);
        }

        public void Delete(Configuration configuration)
        {
            _context.Configurations.Remove(configuration);
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
