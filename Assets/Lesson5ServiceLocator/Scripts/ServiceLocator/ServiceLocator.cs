﻿using System;
using System.Collections.Generic;

namespace Lesson5ServiceLocator.Scripts
{
    public static class ServiceLocator
    {
        private static readonly List<object> services = new List<object>();

        public static List<T> GetServices<T>()
        {
            var result = new List<T>();
            foreach (var service in services)
            {
                if (service is T tService)
                {
                    result.Add(tService);
                }
            }

            return result;
        }

        public static T GetService<T>()
        {
            foreach (var service in services)
            {
                if (service is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Service of type {typeof(T).Name} is not found");
        }

        public static void AddService(object service)
        {
            services.Add(service);
        }
    }
}