namespace DI_Library
{
    public class CycleException : Exception
    {
        public CycleException(string msg)
            : base(msg)
        {

        }
    }
}
