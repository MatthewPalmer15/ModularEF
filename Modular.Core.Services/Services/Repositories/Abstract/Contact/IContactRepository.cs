using Modular.Core.Entities;
using Modular.Core.Interfaces;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface IContactRepository : IRepository<Contact>, IDisposable
    {
    }
}
