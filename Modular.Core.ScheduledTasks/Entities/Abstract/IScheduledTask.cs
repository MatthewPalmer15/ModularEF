using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.Entities.Abstract
{
    public interface IScheduledTask
    {

        public enum StatusType
        {
            Unknown,
            Active,
            Awaiting,
            Stopped,
            Completed
        }

        public string JobId { get; set; }

        public DateTime Started { get; set; }

        public StatusType Status { get; set; }

        public string? ParentJobId { get; set; }

    }
}
