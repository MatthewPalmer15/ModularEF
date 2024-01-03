using Modular.Core.Entities.Abstract;

namespace Modular.Core.Entities.Concrete
{
    public class ScheduledTask : IScheduledTask
    {

        internal ScheduledTask() 
        {
            this.JobId = string.Empty;
            this.Started = DateTime.Now;
            this.Status = IScheduledTask.StatusType.Unknown;
        }
        internal ScheduledTask(string name, IScheduledTask.StatusType status)
        {
            this.JobId = name;
            this.Started = DateTime.Now;
            this.Status = status;
        }

        public string JobId { get; set; }

        public DateTime Started { get; set; }

        public IScheduledTask.StatusType Status { get; set; }

        public string? ParentJobId { get; set; }

    }
}
