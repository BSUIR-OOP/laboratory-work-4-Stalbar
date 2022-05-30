namespace DI_Library
{
    public class CollectionOfServices
    {
        private List<DescriptorOfService> servicesList = new List<DescriptorOfService>();

        public void AddSingelton<TService, TImplementation>()
            => servicesList.Add(new DescriptorOfService(typeof(TService), typeof(TImplementation), LifeTime.Singleton));

        public void AddTransient<TService, TImplementation>()
            => servicesList.Add(new DescriptorOfService(typeof(TService), typeof(TImplementation), LifeTime.Transient));

        public DIContainer GetContainer()
            => new DIContainer(servicesList);
    }
}
