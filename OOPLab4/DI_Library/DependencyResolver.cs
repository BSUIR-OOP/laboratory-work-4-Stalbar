namespace DI_Library
{
    public class DependencyResolver
    {
        DependencyContainer container;
        
        public DependencyResolver(DependencyContainer _container)
        {
            container = _container;
        }

        public T GetService<T>()
            => (T)GetService(typeof(T), true);

        public object GetService(Type type, bool isInterface)
        {
            Dependency dependency;
            dependency = (isInterface == true) ? container.GetFromInterface(type) : container.GetFromClass(type);
            var constructor = dependency._Type.GetConstructors().Single();
            var pararmetrs = constructor.GetParameters().ToArray();
            if (pararmetrs.Length > 0)
            {
                var parameterImplementation = new object[pararmetrs.Length];

                for (int i = 0; i < pararmetrs.Length; i++)
                {
                    parameterImplementation[i] = GetService(pararmetrs[i].ParameterType, false);
                }
                return CreateImplementation(dependency, t => Activator.CreateInstance(t, parameterImplementation));
            }
            return CreateImplementation(dependency, t => Activator.CreateInstance(t));
        }

        public object CreateImplementation(Dependency dependency, Func<Type, object> factory)
        {
            var implementation = factory(dependency._Type);
            if (dependency.LifeTime == DependecyLifeTime.Singleton)
            {
                dependency.AddImplementation(implementation);
            }

            return implementation;
        }
    }
}
