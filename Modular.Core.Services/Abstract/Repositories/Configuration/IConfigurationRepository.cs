using Modular.Core.Interfaces;
using Modular.Core.Models.Config;

namespace Modular.Core.Services.Repositories.Abstract.Config
{
    public interface IConfigurationRepository : IRepository<Configuration>, IDisposable
    {
        string GetValue(string key);

    }
}
