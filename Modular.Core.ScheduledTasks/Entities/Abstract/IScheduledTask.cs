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
            Unknown = 0,
            Enqueued = 1,       //  The job is waiting to be processed.
            Scheduled = 2,      //  The job is scheduled to be processed at a later time.
            Processing = 3,     //  The job is currently being processed.
            Failed = 4,         //  The job has completed with an exception or error.
            Succeeded = 5,      //  The job has completed successfully.
            Deleted = 6,        //  The job has been manually deleted.
            Awaiting = 7,       //  The job is waiting for a dependent job to complete.
            Paused = 8          //  The job is paused.
        }

        public string JobId { get; set; }

        public DateTime Started { get; set; }

        public StatusType Status { get; set; }

        public string? ParentJobId { get; set; }

    }
}
