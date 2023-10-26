using Modular.Core.Interfaces;
using Modular.Core.Models.Config;

namespace Modular.Core.Services.Abstract.Config
{
    public interface IConfigurationRepository : IRepository<Configuration>, IDisposable
    {
        string GetValue(string key);

    }
}
