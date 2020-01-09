namespace CS6
{
    public static class LoggerExtensions
    {
        public static void Add(this Logger logger, string log)
        {
            logger?.WriteLine(log);
        }
    }
}
