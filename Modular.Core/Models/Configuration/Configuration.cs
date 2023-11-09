
#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core.Models.Config
{
    public class Configuration : BaseEntity, IAuditable
    {

        public string Key { get; set; }

        public string Value { get; set; }

    }
}
