using Quartz;
using Quartz.Spi;
using quartz_sample.Interfaces;

namespace quartz_sample.Services
{
    public class StructureMapJobFactory : IJobFactory
    {
        private readonly IResolver _resolver;

        public StructureMapJobFactory(IResolver resolver)
        {
            _resolver = resolver;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _resolver.Resolve<IJob>(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {

        }
    }
}
