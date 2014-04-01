using System;
using System.Collections.Generic;
using quartz_sample.Interfaces;
using StructureMap;
using StructureMap.Graph;

namespace quartz_sample.Services
{
    class StructureMapResolver : IResolver
    {
        public StructureMapResolver()
        {
            ObjectFactory.Initialize(expression =>
                expression.Scan(scanner =>
                                {
                                    scanner.AssembliesFromApplicationBaseDirectory();
                                    scanner.WithDefaultConventions();
                                    scanner.LookForRegistries();
                                })
                );
        }

        public T Resolve<T>() where T : class
        {
            return ObjectFactory.GetInstance<T>();
        }

        public T Resolve<T>(Type subType) where T : class
        {
            return (T) ObjectFactory.GetInstance(subType);
        }

        public IEnumerable<T> ResolveAll<T>() where T : class
        {
            return ObjectFactory.GetAllInstances<T>();
        }
    }
}
