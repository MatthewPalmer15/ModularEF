using Modular.Core.Interfaces;
using Modular.Core.Models.Entity;

namespace Modular.Core.Services.Repositories.Abstract.Entity
{
    public interface IContactRepository : IRepository<Contact>, IDisposable
    {
    }
}
