
namespace Modular.Core
{
    public class BaseEntity
    {

        #region "  Properties  "

        public Guid ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Guid ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }

        #endregion

    }
}
