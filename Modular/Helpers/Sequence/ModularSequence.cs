using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Helpers
{
    public class Sequence : ModularBaseEntity
    {

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Count { get; set; }

    }
}
