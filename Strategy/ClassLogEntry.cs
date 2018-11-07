using System;

namespace Strategy
{
    internal class ClassLogEntry : ILogReader
    {
        public DateTime DTime { get; set; }
        public string Message { get; set; }
    }
}
