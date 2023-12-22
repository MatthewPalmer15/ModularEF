#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core
{
    public class BaseEntity<T> : IBaseEntity<T>
    {

        public enum StatusType
        {
            Unknown = 0,
            Active = 1,
            Inactive = 2,
            Cancelled = 3,
            Flagged = 50,
            Deleted = 100,
        }

        public T Id { get; set; }

        public DateTime Created { get; set; }

        public StatusType Status { get; set; }

        public bool IsFlagged => Status == StatusType.Flagged;

        public bool IsDeleted => Status == StatusType.Deleted;

    }
}
