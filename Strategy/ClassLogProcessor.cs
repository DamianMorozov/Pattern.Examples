using System;
using System.Collections.Generic;

namespace Strategy
{
    internal class ClassLogProcessor
    {
        private readonly Func<List<ClassLogEntry>> _logImporter;

        public ClassLogProcessor(Func<List<ClassLogEntry>> logImporter)
        {
            _logImporter = logImporter;
        }

        public void ProcessLogs()
        {
            foreach (var logEntry in _logImporter.Invoke())
            {
                SaveLogEntry(logEntry);
            }
        }

        private void SaveLogEntry(ClassLogEntry logEntry)
        {
            Console.WriteLine(nameof(ClassLogProcessor) + "." + nameof(SaveLogEntry) + "()");
        }
    }
}
