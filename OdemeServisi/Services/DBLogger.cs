namespace OdemeSistemi.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[Console Logger] - " + message);
        }
    }
}
