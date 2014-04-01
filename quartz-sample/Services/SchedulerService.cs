using Quartz;
using quartz_sample.Interfaces;
using quartz_sample.Jobs;

namespace quartz_sample.Services
{
    public class SchedulerService : IChildService
    {
        private readonly IScheduler _scheduler;

        public SchedulerService(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void Start()
        {
            ScheduleJob<JohnnyFiveAliveJob>("0/5 * * * * ?");

            _scheduler.Start();
        }

        public void Stop()
        {
            _scheduler.Shutdown(true);
        }

        private void ScheduleJob<T>(string cronExpression) where T : IJob
        {
            string jobName = typeof(T).Name;
            string triggerName = typeof(T).Name;
            var jobDetail = JobBuilder.Create<T>().WithIdentity(jobName).Build();
            var trigger = TriggerBuilder.Create().WithCronSchedule(cronExpression).WithIdentity(triggerName).Build();
            _scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
