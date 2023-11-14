
#nullable disable

namespace Modular.Core.Models.Misc
{
    public class Department : BaseEntity<Guid>
    {

        #region "  Properties  "

        public string Name { get; set; }

        public string Description { get; set; }

        #endregion

    }
}
