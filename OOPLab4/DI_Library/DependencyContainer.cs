namespace DI_Library
{
    public class DependencyContainer
    {
        List<Dependency> dependencies = new List<Dependency>();

        public DependencyContainer() { }

        public void AddSingleton<T, TImplementation>()
            => dependencies.Add(new Dependency(typeof(T), typeof(TImplementation), DependecyLifeTime.Singleton));

        public void AddTransient<T, TImplementation>()
            => dependencies.Add(new Dependency(typeof(T), typeof(TImplementation), DependecyLifeTime.Transient));

        public Dependency GetFromInterface(Type interfaceType)
            => dependencies.FirstOrDefault(x => x.InterfaceType == interfaceType);

        public Dependency GetFromClass(Type classType)
            => dependencies.FirstOrDefault(x => x._Type.Name == classType.Name);
    }
}
