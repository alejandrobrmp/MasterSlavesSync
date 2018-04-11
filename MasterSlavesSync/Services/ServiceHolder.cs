using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSlavesSync.Services
{
    public static class ServiceHolder
    {
        private static Dictionary<Type, IService> services;

        static ServiceHolder()
        {
            services = new Dictionary<Type, IService>();
        }

        public static T GetService<T>() where T : IService, new()
        {
            Type t = typeof(T);
            if (services.ContainsKey(t))
            {
                return (T)services[t];
            }
            else
            {
                IService service = new T();
                services.Add(t, service);
                return (T)service;
            }
        }
    }
}
