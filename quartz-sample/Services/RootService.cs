using System.Collections.Generic;
using quartz_sample.Interfaces;

namespace quartz_sample.Services
{
    public class RootService : IRootService
    {
        private readonly IEnumerable<IChildService> _childServices;

        public RootService(IEnumerable<IChildService> childServices)
        {
            _childServices = childServices;
        }

        public void Start()
        {
            foreach (var childService in _childServices)
                childService.Start();
        }

        public void Stop()
        {
            foreach (var childService in _childServices)
                childService.Stop();
        }
    }
}
