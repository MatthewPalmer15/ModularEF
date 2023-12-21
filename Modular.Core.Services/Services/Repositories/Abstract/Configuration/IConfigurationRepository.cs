using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface IConfigurationRepository : IRepository<Configuration>, IDisposable
    {

        public Configuration New(string key, string value);

        public string? GetValue(string key);

    }
}
