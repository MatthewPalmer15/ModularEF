using Hangfire;
using Modular.Core.Entities.Concrete;
using Modular.Core.ScheduledTasks.Abstract;
using Modular.Core.Services.Repositories.Abstract;
using System.Linq.Expressions;

namespace Modular.Core.ScheduledTasks.Concrete
{
    public class ScheduledTaskService : IScheduledTaskService
    {

        private readonly IScheduledTaskRepository _repository;

        public ScheduledTaskService(IScheduledTaskRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds a background job.
        /// </summary>
        /// <param name="methodCall"></param>
        public void AddBackgroundJob(Expression<Action> methodCall)
        {
            string jobId = BackgroundJob.Enqueue(methodCall);
            _repository.Add(new ScheduledTask(jobId, Entities.Abstract.IScheduledTask.StatusType.Completed));

        }

        /// <summary>
        /// Adds a background job with a delay.
        /// </summary>
        /// <param name="methodCall"></param>
        /// <param name="delay"></param>
        public void AddBackgroundJob(Expression<Action> methodCall, TimeSpan delay)
        {
            string jobId = BackgroundJob.Schedule(methodCall, delay);
            _repository.Add(new ScheduledTask(jobId, Entities.Abstract.IScheduledTask.StatusType.Completed));

        }

        /// <summary>
        /// Continue background job after one job is completed.
        /// </summary>
        /// <param name="methodCall"></param>
        /// <param name="parentJobId"></param>
        public void ContinueBackgroundJob(Expression<Action> methodCall, string parentJobId)
        {
            bool isParentTaskExist = _repository.Exists(parentJobId);
            if (isParentTaskExist)
            {
                BackgroundJob.ContinueJobWith(parentJobId, methodCall);
            }
        }

        /// <summary>
        /// Deletes background job.
        /// </summary>
        /// <param name="jobId"></param>
        public void DeleteBackgroundJob(string jobId)
        {
            BackgroundJob.Delete(jobId);
        }

        /// <summary>
        /// Requeues background job.
        /// </summary>
        /// <param name="jobId"></param>
        public void RequeueBackgroundJob(string jobId)
        {
            BackgroundJob.Requeue(jobId);
        }

        /// <summary>
        /// Reschedules background job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="delay"></param>
        public void RescheduleBackgroundJob(string jobId, TimeSpan delay)
        {
            BackgroundJob.Reschedule(jobId, delay);
        }

        /// <summary>
        /// Adds a recurring job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="jobAction"></param>
        /// <param name="cronExpression"></param>
        public void AddRecurringJob(string jobId, Expression<Func<Task>> jobAction, string cronExpression)
        {
            RecurringJob.AddOrUpdate(jobId, jobAction, cronExpression);
        }

        /// <summary>
        /// Removes a recurring job.
        /// </summary>
        /// <param name="jobId"></param>
        public void RemoveRecurringJob(string jobId)
        {
            RecurringJob.RemoveIfExists(jobId);
        }

        /// <summary>
        /// Trigger a recurring job.
        /// </summary>
        /// <param name="jobId"></param>
        public void TriggerRecurringJob(string jobId)
        {
            RecurringJob.TriggerJob(jobId);
        }

    }
}
