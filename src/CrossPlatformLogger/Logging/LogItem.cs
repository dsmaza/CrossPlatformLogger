using System;

namespace CrossPlatformLogger.Logging
{
    public struct LogItem
    {
        public LogItem(LogLevel level, string message, Type category)
        {
            Level = level;
            Message = message;
            Category = category;
            When = DateTime.UtcNow;
        }

        public LogLevel Level { get; }

        public string Message { get; }

        public DateTime When { get; }

        public Type Category { get; }
    }
}
