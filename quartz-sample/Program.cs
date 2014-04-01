using log4net.Config;
using quartz_sample.Framework;
using quartz_sample.Interfaces;
using quartz_sample.Services;
using Topshelf;

namespace quartz_sample
{
    class Program
    {
        private static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            Locator.Resolver = new StructureMapResolver();

            HostFactory.Run(x =>
                            {
                                x.UseLog4Net();
                                x.Service<IRootService>(s =>
                                                        {
                                                            s.ConstructUsing(y => Locator.Resolve<IRootService>());
                                                            s.WhenStarted(tc => tc.Start());
                                                            s.WhenStopped(tc => tc.Stop());
                                                        });
                                x.RunAsLocalSystem();
                                x.SetDescription("Quartz Sample Service");
                                x.SetDisplayName("QuartzSampleService");
                                x.SetServiceName("QuartzSampleService");
                            });
        }
    }
}
