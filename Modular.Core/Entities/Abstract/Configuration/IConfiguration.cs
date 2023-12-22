using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Abstract
{
    public interface IConfiguration : IBaseEntity<Guid>
    {

        public string Key { get; set; }

        public string Value { get; set; }

    }
}
