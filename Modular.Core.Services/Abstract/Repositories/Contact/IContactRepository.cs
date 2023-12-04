using Modular.Core.Interfaces;
using Modular.Core.Entities;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface IContactRepository : IRepository<Contact>, IDisposable
    {
    }
}
