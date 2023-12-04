using Modular.Core.Interfaces;
using Modular.Core.Entities;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface ICountryRepository : IRepository<Country>, IDisposable
    {
    }
}
