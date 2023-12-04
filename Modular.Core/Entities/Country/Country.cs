#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core.Entities
{
    public class Country : BaseEntity<Guid>, IAuditable
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

    }
}
