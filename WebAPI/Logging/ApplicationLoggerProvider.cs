namespace WebAPI.Logging
{
    public class ApplicationLoggerProvider : ILoggerProvider
    {
        private readonly IDbContextFactory<LoggingAPIContext> _contextFactory;

        public ApplicationLoggerProvider(IDbContextFactory<LoggingAPIContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(_contextFactory);
        }

        public void Dispose()
        {

        }
    }
}
