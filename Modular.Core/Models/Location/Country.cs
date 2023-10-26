using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Models.Location
{
    public class Country : BaseEntity
    {

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty; 

        public Guid ContinentID { get; set; } = Guid.Empty;

        public virtual Continent Continent { get; set; } = null!;

    }
}
