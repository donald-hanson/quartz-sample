using System;
using System.Collections.Generic;
using quartz_sample.Interfaces;

namespace quartz_sample.Services
{
    public class NullResolver : IResolver
    {
        public T Resolve<T>() where T : class
        {
            return default(T);
        }

        public T Resolve<T>(Type subType) where T : class
        {
            return default(T);
        }

        public IEnumerable<T> ResolveAll<T>() where T : class
        {
            return new T[] { };
        }
    }
}
