using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;
using quartz_sample.Interfaces;
using quartz_sample.Services;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace quartz_sample.Framework
{
    public class QuartzSampleRegistry : Registry
    {
        public QuartzSampleRegistry()
        {
            For<IResolver>().Use(() => Locator.Resolver);
            For<IScheduler>().Singleton().Use(context => CreateScheduler(context));
            For<ISchedulerFactory>().Singleton().Use(() => CreateSchedulerFactory());

            Scan(x =>
            {
                x.AssemblyContainingType<IChildService>();
                x.AddAllTypesOf<IChildService>();
            });
        }

        private static IScheduler CreateScheduler(IContext context)
        {
            var scheduler = context.GetInstance<ISchedulerFactory>().GetScheduler();
            scheduler.JobFactory = context.GetInstance<StructureMapJobFactory>();
            return scheduler;
        }

        private static ISchedulerFactory CreateSchedulerFactory()
        {
            return new StdSchedulerFactory(new NameValueCollection());
        }
    }
}
