using System.Reflection;

namespace DI_Library
{
    public class DIContainer
    {
        private List<DescriptorOfService> descriptors;

        public DIContainer(List<DescriptorOfService> descriptors)
        {
            this.descriptors = descriptors;
        }

        public T GetService<T>()
            => (T)GetService(typeof(T));

        private object GetService(Type serviceType)
        {
            DescriptorOfService service = descriptors.SingleOrDefault(x => x.TypeOfService == serviceType);
            DescriptorOfService descriptor = descriptors.SingleOrDefault(x => x.TypeOfService == serviceType);
            if (descriptor.Implementation != null)
                return descriptor.Implementation;

            Type actType = descriptor.TypeOfImplementation == null ? descriptor.TypeOfService : descriptor.TypeOfImplementation;

            ConstructorInfo constructorInfo = actType.GetConstructors()[0];

            object[] parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actType, parameters);

            if (descriptor.Lifetime == LifeTime.Singleton)
                descriptor.Implementation = implementation;

            return implementation;
        }
    }
}
