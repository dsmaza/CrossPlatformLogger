namespace CrossPlatformLogger.Logging
{
    public class FileLoggerFactory : ILoggerFactory
    {
        private readonly string logsDirectory;
        private readonly System.Func<LogItem, string> pathBuilder;
        private readonly System.Func<LogItem, string> messageBuilder;

        public FileLoggerFactory(string logsDirectory)
        {
            this.logsDirectory = logsDirectory;
            if (!System.IO.Directory.Exists(logsDirectory))
            {
                System.IO.Directory.CreateDirectory(logsDirectory);
            }

            pathBuilder = BuildPath;
            messageBuilder = BuildMessage;
        }

        public ILogger<T> Create<T>()
        {
            return new FileLogger<T>(pathBuilder, messageBuilder);
        }

        private string BuildPath(LogItem logItem)
        {
            // customize for your needs
            var fileName = $"{logItem.Category.Name}_{logItem.When:yyyyMMdd}.log";
            var path = System.IO.Path.Combine(logsDirectory, fileName);
            return path;
        }

        private string BuildMessage(LogItem logItem)
        {
            // customize for your needs
            var message = $"{logItem.When:yyyy-MM-dd HH:mm:ss}\t{logItem.Level}\t{logItem.Message}{System.Environment.NewLine}";
            return message;
        }
    }
}
