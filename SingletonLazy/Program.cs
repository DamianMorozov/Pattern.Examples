using System;

namespace SingletonLazy
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---            Examples of program development patterns            ---");
            Console.WriteLine(@"---                         Lazy Singleton                         ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"ClassLazySingleton.Instance = " + ClassLazySingleton.Instance);
            Console.WriteLine(@"ClassLazySingleton.Instance.GetHashCode() = " + ClassLazySingleton.Instance.GetHashCode());
            ClassLazySingleton.SomeStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"Press Enter to close.");
            Console.ReadLine();
        }
    }
}
