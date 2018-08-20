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

            Console.WriteLine(@"ClassLazySingletonWithStaticMethod.Instance = " + ClassLazySingletonWithStaticMethod.Instance);
            Console.WriteLine(@"ClassLazySingletonWithStaticMethod.Instance.GetHashCode() = " + ClassLazySingletonWithStaticMethod.Instance.GetHashCode());
            ClassLazySingletonWithStaticMethod.SomeStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var lazySingleton1 = ClassLazySingleton.Instance;
            Console.WriteLine(@"lazySingleton1 = " + lazySingleton1);
            Console.WriteLine(@"lazySingleton1.GetHashCode() = " + lazySingleton1.GetHashCode());
            lazySingleton1.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var lazySingleton2 = ClassLazySingleton.Instance;
            Console.WriteLine(@"lazySingleton2 = " + lazySingleton2);
            Console.WriteLine(@"lazySingleton2.GetHashCode() = " + lazySingleton2.GetHashCode());
            lazySingleton2.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"Press Enter to close.");
            Console.ReadLine();
        }
    }
}
