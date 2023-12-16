using Modular.Core.Entities;
using Modular.Core.Interfaces;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface ICountryRepository : IRepository<Country>, IDisposable
    {

        public Country New(string name, string description, string code);

    }
}
