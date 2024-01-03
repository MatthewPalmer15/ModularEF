using Hangfire;
using Modular.Core.Entities.Concrete;
using Modular.Core.ScheduledTasks.Abstract;
using Modular.Core.Services.Repositories.Abstract;
using System.Linq.Expressions;
using Modular.Core.Entities.Abstract;
using Hangfire.Storage;

namespace Modular.Core.Services
{
    public class ScheduledTaskService : IScheduledTaskService
    {

        private readonly IScheduledTaskRepository _repository;

        public ScheduledTaskService(IScheduledTaskRepository repository)
        {
            _repository = repository;

            RecurringJob.AddOrUpdate("CheckJobStatus", () => CheckJobStatus(), Cron.Minutely);
        }

        private void CheckJobStatus()
        {
            IStorageConnection connection = JobStorage.Current.GetConnection();

            var tasks = _repository.Search(x => x.Status is not IScheduledTask.StatusType.Unknown and not IScheduledTask.StatusType.Unknown);
            foreach(var task in tasks)
            {
                JobData jobData = connection.GetJobData(task.JobId);
                task.Status = ScheduledTaskUtils.ConvertStatusToEnum(jobData.State);
            }
            _repository.SaveChanges();
        }

        /// <summary>
        /// Adds a background job.
        /// </summary>
        /// <param name="methodCall"></param>
        public void AddBackgroundJob(Expression<Action> methodCall)
        {
            string jobId = BackgroundJob.Enqueue(methodCall);
            _repository.Add(new ScheduledTask(jobId, IScheduledTask.StatusType.Awaiting));

        }

        /// <summary>
        /// Adds a background job with a delay.
        /// </summary>
        /// <param name="methodCall"></param>
        /// <param name="delay"></param>
        public void AddBackgroundJob(Expression<Action> methodCall, TimeSpan delay)
        {
            string jobId = BackgroundJob.Schedule(methodCall, delay);
            _repository.Add(new ScheduledTask(jobId, IScheduledTask.StatusType.Scheduled));

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
                string jobId = BackgroundJob.ContinueJobWith(parentJobId, methodCall);
                _repository.Add(new ScheduledTask(jobId, IScheduledTask.StatusType.Awaiting));
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
            _repository.Add(new ScheduledTask(jobId, IScheduledTask.StatusType.Awaiting));
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
