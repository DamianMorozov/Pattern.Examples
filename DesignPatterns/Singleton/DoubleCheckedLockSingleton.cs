using System;

namespace DesignPatterns.Singleton
{
    internal class DoubleCheckedLockSingleton
    {
        private static volatile DoubleCheckedLockSingleton _instance;
        private static readonly object _syncRoot = new object();
        public static DoubleCheckedLockSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleCheckedLockSingleton();
                        }
                    }
                }
                return _instance;
            }
        }

        private DoubleCheckedLockSingleton() { }

        public void SomeNonStaticMethod()
        {
            Console.WriteLine(@"call public void SomeNonStaticMethod()");
        }
    }
}
