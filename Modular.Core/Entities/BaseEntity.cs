#nullable disable

using Modular.Core.Interfaces;

namespace Modular.Core
{
    public class BaseEntity<T> : IBaseEntity<T>
    {


        public T Id { get; set; }

        public DateTime Created { get; set; }

        public StatusType Status { get; set; }

        public bool IsFlagged => Status == StatusType.Flagged;

        public bool IsDeleted => Status == StatusType.Deleted;

    }
}
