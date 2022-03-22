namespace WebAPI.Models
{
    public partial class Log
    {
        public int LogId { get; set; }
        public string LogLevel { get; set; }
        public string Source { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string CreatedDate { get; set; }
    }
}
