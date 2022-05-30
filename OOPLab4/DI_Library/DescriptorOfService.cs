﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Library
{
    public class DescriptorOfService
    {
        public Type TypeOfService { get; set; }

        public Type TypeOfImplementation { get; set; }

        public object Implementation { get; set; }

        public LifeTime Lifetime { get; set; }

        public DescriptorOfService(Type serviceType, Type implementationType, LifeTime lifetime)
        {
            TypeOfService = serviceType;
            TypeOfImplementation = implementationType;
            Lifetime = lifetime; 
        }
    }
}
