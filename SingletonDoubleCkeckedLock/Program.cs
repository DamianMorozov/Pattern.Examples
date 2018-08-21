using System;

namespace SingletonDoubleCkeckedLock
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---            Examples of program development patterns            ---");
            Console.WriteLine(@"---                    Double checked Singleton                    ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var doubleCheckedLockSingleton1 = ClassDoubleCheckedLockSingleton.Instance;
            Console.WriteLine(@"doubleCheckedLockSingleton1 = " + doubleCheckedLockSingleton1);
            Console.WriteLine(@"doubleCheckedLockSingleton1.GetHashCode() = " + doubleCheckedLockSingleton1.GetHashCode());
            doubleCheckedLockSingleton1.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var doubleCheckedLockSingleton2 = ClassDoubleCheckedLockSingleton.Instance;
            Console.WriteLine(@"doubleCheckedLockSingleton2 = " + doubleCheckedLockSingleton2);
            Console.WriteLine(@"doubleCheckedLockSingleton2.GetHashCode() = " + doubleCheckedLockSingleton2.GetHashCode());
            doubleCheckedLockSingleton2.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"Press Enter to close.");
            Console.ReadLine();
        }
    }
}
