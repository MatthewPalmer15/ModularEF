
using System.Linq.Expressions;

namespace Modular.Core.ScheduledTasks.Abstract
{
    public interface IScheduledTaskService
    {

        public void AddBackgroundJob(Expression<Action> methodCall);

        public void AddBackgroundJob(Expression<Action> methodCall, TimeSpan delay);

        public void ContinueBackgroundJob(Expression<Action> methodCall, string parentJobId);

        public void DeleteBackgroundJob(string jobId);

        public void RequeueBackgroundJob(string jobId);

        public void RescheduleBackgroundJob(string jobId, TimeSpan delay);

        public void AddRecurringJob(string jobId, Expression<Func<Task>> jobAction, string cronExpression);

        public void RemoveRecurringJob(string jobId);

        public void TriggerRecurringJob(string jobId);

    }
}
