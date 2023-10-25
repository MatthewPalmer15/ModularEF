using Modular.Core.Interfaces;
using Modular.Core.Models.Sequence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Services.Repositories.Abstract.Sequence
{
    public interface ISequenceRepository : IRepository<Models.Sequence.Sequence>, IDisposable
    {
        public int GetValue();
    }
}
