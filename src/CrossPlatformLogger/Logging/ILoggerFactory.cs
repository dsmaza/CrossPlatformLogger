namespace CrossPlatformLogger.Logging
{
    public interface ILoggerFactory
    {
        ILogger<T> Create<T>();
    }
}
