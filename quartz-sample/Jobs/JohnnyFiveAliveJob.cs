using System;
using log4net;
using Quartz;

namespace quartz_sample.Jobs
{
    [DisallowConcurrentExecution]
    public class JohnnyFiveAliveJob : IJob
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (JohnnyFiveAliveJob));

        public void Execute(IJobExecutionContext context)
        {
            Log.DebugFormat("Johnny Five is alive! {0}", DateTime.Now);
        }
    }
}
