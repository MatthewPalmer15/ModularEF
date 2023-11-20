#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core.Models.Misc
{
    public class Occupation : BaseEntity<Guid>, IAuditable
    {

        #region "  Properties  "

        public string Name { get; set; }

        public string Description { get; set; }

        #endregion

    }
}
