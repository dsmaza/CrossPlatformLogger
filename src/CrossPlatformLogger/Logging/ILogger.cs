namespace CrossPlatformLogger.Logging
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);
    }

    public interface ILogger<T> : ILogger
    {
    }
}
