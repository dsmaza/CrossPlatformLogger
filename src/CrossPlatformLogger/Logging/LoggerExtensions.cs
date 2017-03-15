using System;

namespace CrossPlatformLogger.Logging
{
    public static class LoggerExtensions
    {
        public static void LogDebug(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Debug, message);
        }

        public static void LogInfo(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Info, message);
        }

        public static void LogWarn(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Warn, message);
        }

        public static void LogError(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Error, message);
        }

        public static void LogError(this ILogger logger, Exception ex)
        {
            logger.Log(LogLevel.Error, ex.ToString());
        }

        public static void LogCritical(this ILogger logger, string message)
        {
            logger.Log(LogLevel.Critical, message);
        }

        public static void LogCritical(this ILogger logger, Exception ex)
        {
            logger.Log(LogLevel.Critical, ex.ToString());
        }
    }
}
