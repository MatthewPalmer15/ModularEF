using Modular.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modular.Core.ScheduledTasks
{
    internal static class ScheduledTaskUtils
    {

        public static IScheduledTask.StatusType ConvertStatusToEnum(string statusName)
        {
            IScheduledTask.StatusType status;
            switch (statusName.Trim().ToUpperInvariant())
            {
                //  Enqueued
                case "ENQUEUED":
                    status = IScheduledTask.StatusType.Enqueued;
                    break;

                //  Scheduled
                case "SCHEDULED":
                    status = IScheduledTask.StatusType.Scheduled;
                    break;

                //  Processing
                case "PROCESSING":
                    status = IScheduledTask.StatusType.Processing;
                    break;

                //  Failed
                case "FAILED":
                    status = IScheduledTask.StatusType.Failed;
                    break;

                //  Succeeded
                case "SUCCEEDED":
                    status = IScheduledTask.StatusType.Succeeded;
                    break;

                //  Deleted
                case "DELETED":
                    status = IScheduledTask.StatusType.Deleted;
                    break;

                //  Awaiting
                case "AWAITING":
                    status = IScheduledTask.StatusType.Awaiting;
                    break;

                //  Paused
                case "PAUSED":
                    status = IScheduledTask.StatusType.Paused;
                    break;

                //  Unknown
                default:
                    status = IScheduledTask.StatusType.Unknown; 
                    break;
            }

            return status;
        }


    }
}
