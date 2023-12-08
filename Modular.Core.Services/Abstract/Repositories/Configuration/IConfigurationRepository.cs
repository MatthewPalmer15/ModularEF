using Modular.Core.Entities;
using Modular.Core.Interfaces;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface IConfigurationRepository : IRepository<Configuration>, IDisposable
    {
        string GetValue(string key);

    }
}
