using Modular.Core.Interfaces;
using Modular.Core.Entities;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface IConfigurationRepository : IRepository<Configuration>, IDisposable
    {
        string GetValue(string key);

    }
}
