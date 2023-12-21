using Modular.Core.Interfaces;

namespace Modular.Core.Entities.Abstract
{
    public interface ICountry : IBaseEntity<Guid>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Code { get; set; }

    }
}
