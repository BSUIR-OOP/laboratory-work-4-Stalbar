namespace DI_Library
{
    public class Dependency
    {
        public Type _Type { get; set; }
        public Type InterfaceType { get; set; }

        public DependecyLifeTime LifeTime { get; set; }

        public object Implementation { get; set; }

        public Dependency(Type _type, Type interfaceType, DependecyLifeTime lifeTime )
        {
            _Type = _type;
            InterfaceType = interfaceType;
            LifeTime = lifeTime;
        }

        public void AddImplementation(object obj)
        {
            Implementation = obj;
        }
    }
}
