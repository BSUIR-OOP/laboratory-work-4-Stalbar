using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Library
{
    public class CollectionOfServices
    {
        private List<DescriptorOfService> servicesList = new List<DescriptorOfService>();

        public void AddSingelton<TService, TImplementation>()
            => servicesList.Add(new DescriptorOfService(typeof(TService), typeof(TImplementation), LifeTime.Singleton));

        public void AddTransient<TService, TImplementation>()
            => servicesList.Add(new DescriptorOfService(typeof(TService), typeof(TImplementation), LifeTime.Transient));
    }
}
