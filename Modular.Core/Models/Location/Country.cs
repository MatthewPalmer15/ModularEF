#nullable disable

namespace Modular.Core.Models.Location
{
    public class Country : BaseEntity<Guid>
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }

    }
}
