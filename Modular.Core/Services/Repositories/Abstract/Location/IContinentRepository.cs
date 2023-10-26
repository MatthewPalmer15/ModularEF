using Modular.Core.Interfaces;
using Modular.Core.Models.Audit;
using Modular.Core.Models.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Services.Repositories.Abstract.Location
{
    public interface IContinentRepository : IRepository<Continent>, IDisposable
    {
    }
}
