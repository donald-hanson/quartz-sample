using System;
using System.Collections.Generic;

namespace quartz_sample.Interfaces
{
    public interface IResolver
    {
        T Resolve<T>() where T : class;
        T Resolve<T>(Type subType) where T : class;
        IEnumerable<T> ResolveAll<T>() where T : class;
    }
}
