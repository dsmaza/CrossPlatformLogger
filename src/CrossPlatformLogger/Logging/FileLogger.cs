namespace CrossPlatformLogger.Logging
{
    public class FileLogger<T> : ILogger<T>
    {
        private readonly System.Func<LogItem, string> pathBuilder;
        private readonly System.Func<LogItem, string> messageBuilder;

        public FileLogger(System.Func<LogItem, string> pathBuilder,
            System.Func<LogItem, string> messageBuilder)
        {
            this.pathBuilder = pathBuilder;
            this.messageBuilder = messageBuilder;
        }

        public virtual void Log(LogLevel level, string message)
        {
            var logItem = new LogItem(level, message, typeof(T));
            var path = pathBuilder(logItem);
            var text = messageBuilder(logItem);
            System.IO.File.AppendAllText(path, text, System.Text.Encoding.UTF8);
        }
    }
}
