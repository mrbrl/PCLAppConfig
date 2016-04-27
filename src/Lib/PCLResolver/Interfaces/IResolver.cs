using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLResolver.Enum;

namespace PCLResolver.Interfaces
{
    public interface IResolver
    {
        T Resolve<T>() where T : class;

        object Resolve(Type type);

        void Register<TInterface, TImplementation>(LifetimeScope lifetimeScope = LifetimeScope.InstancePerDependency);

        void Register<TInterface>(LifetimeScope lifetimeScope = LifetimeScope.InstancePerDependency);

        void RegisterMultiple<TImplementation>(LifetimeScope lifetimeScope, params Type[] interfaces) where TImplementation : class;

        void RegisterMultiple<TImplementation>(TImplementation instance, LifetimeScope lifetimeScope,
            params Type[] interfaces) where TImplementation : class;

        void RegisterGeneric(Type interfaceType, Type instanceType, LifetimeScope lifetimeScope);

        void Initialise();

        T GetContainer<T>();

        bool IsInitialised { get; set; }

        void Register<TInterface>(TInterface instance) where TInterface : class;

        void Update<TInterface>(TInterface instance) where TInterface : class;

        void UpdateMultiple<TImplementation>(TImplementation instance, LifetimeScope lifetimeScope,
            params Type[] interfaces) where TImplementation : class;

        void Update<TInterface, TImplementation>(LifetimeScope lifetimeScope);
    }
}
