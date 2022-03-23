namespace WebAPI.Logging
{
    public class DatabaseLogger : ILogger
    {
        private readonly IDbContextFactory<LoggingAPIContext> _contextFactory;

        public DatabaseLogger(IDbContextFactory<LoggingAPIContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Log log = new();
            log.LogLevel = logLevel.ToString();
            log.ExceptionMessage = exception?.Message;
            log.StackTrace = exception?.StackTrace;
            log.Source = "Server";
            log.CreatedDate = DateTime.Now.ToString();

            using var context = _contextFactory.CreateDbContext();
            context.Logs.Add(log);
            context.SaveChanges();
        }
    }
}
