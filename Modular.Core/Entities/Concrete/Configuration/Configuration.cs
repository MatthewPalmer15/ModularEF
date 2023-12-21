#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core.Entities
{
    public class Configuration : BaseEntity<Guid>, IAuditable
    {

        public string Key { get; set; }

        public string Value { get; set; }

    }
}
