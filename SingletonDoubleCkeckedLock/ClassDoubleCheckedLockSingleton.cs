using System;

namespace SingletonDoubleCkeckedLock
{
    public class ClassDoubleCheckedLockSingleton
    {
        private static volatile ClassDoubleCheckedLockSingleton _instance;
        private static readonly object _syncRoot = new object();
        public static ClassDoubleCheckedLockSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new ClassDoubleCheckedLockSingleton();
                        }
                    }
                }
                return _instance;
            }
        }

        private ClassDoubleCheckedLockSingleton() { }

        public void SomeNonStaticMethod()
        {
            Console.WriteLine(@"call public void SomeNonStaticMethod()");
        }
    }
}
