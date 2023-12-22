using Modular.Core.Entities.Concrete;
using Modular.Core.Interfaces;

namespace Modular.Core.Services.Repositories.Abstract
{
    public interface IContactRepository : IRepository<Contact>, IDisposable
    {
        public Contact New(string forename, string surname, string email);

    }
}
