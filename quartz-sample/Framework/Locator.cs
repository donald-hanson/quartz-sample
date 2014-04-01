using System;
using System.Collections.Generic;
using quartz_sample.Interfaces;
using quartz_sample.Services;

namespace quartz_sample.Framework
{
    public static class Locator
    {
        static Locator()
        {
            Resolver = new NullResolver();
        }

        public static IResolver Resolver { get; set; }

        public static T Resolve<T>() where T : class
        {
            return Resolver.Resolve<T>();
        }

        public static T Resolve<T>(Type subType) where T : class
        {
            return Resolver.Resolve<T>(subType);
        }

        public static IEnumerable<T> ResolveAll<T>() where T : class
        {
            return Resolver.ResolveAll<T>();
        }
    }
}
