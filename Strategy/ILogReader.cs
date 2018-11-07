using System;

namespace Strategy
{
    internal interface ILogReader
    {
        DateTime DTime { get; set; }
        string Message { get; set; }
    }
}
