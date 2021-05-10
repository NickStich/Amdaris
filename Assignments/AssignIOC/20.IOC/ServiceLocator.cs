using IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace _20.IOC
{
    public static class ServiceLocator
    {
        private static readonly IUnityContainer _unityContainer = new UnityContainer();

        public static void RegisterAll()
        {
            _unityContainer.RegisterType<ICar, Car>(new InjectionConstructor("Car"));
        }

        public static T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public static T Resolve<T>(string vehicleType)
        {
            return _unityContainer.Resolve<T>(vehicleType);
        }
    }
}
