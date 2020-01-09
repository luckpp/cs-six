using System;

namespace CS6
{
    public class WorkerException: Exception
    {
        public WorkerException()
        {
        }

        public WorkerException(string message)
            : base(message)
        {
        }

        public WorkerException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public int Code { get; set; }
    }
}
