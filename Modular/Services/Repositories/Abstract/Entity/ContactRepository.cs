using Modular.Core.Interfaces;
using Modular.Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Services.Abstract.Entity
{
    public interface IContactRepository : IModularRepository<Contact>, IDisposable
    {
    }
}
