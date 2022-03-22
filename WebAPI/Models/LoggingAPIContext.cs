namespace WebAPI.Models
{
    public partial class LoggingAPIContext : DbContext
    {
        public LoggingAPIContext()
        {
        }

        public LoggingAPIContext(DbContextOptions<LoggingAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.LogId).HasColumnName("log_id");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.ExceptionMessage).HasColumnName("exception_message");

                entity.Property(e => e.LogLevel).HasColumnName("log_level");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.StackTrace).HasColumnName("stack_trace");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
