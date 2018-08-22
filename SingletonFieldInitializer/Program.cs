using System;

namespace SingletonFieldInitializer
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---            Examples of program development patterns            ---");
            Console.WriteLine(@"---                  Field initializer Singleton                   ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var fieldInitializerSingleton = ClassFieldInitializerSingleton.Instance;
            Console.WriteLine(@"fieldInitializerSingleton = " + fieldInitializerSingleton);
            Console.WriteLine(@"fieldInitializerSingleton.GetHashCode() = " + fieldInitializerSingleton.GetHashCode());
            fieldInitializerSingleton.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var lazyFieldInitializerSingleton = ClassLazyFieldInitializerSingleton.Instance;
            Console.WriteLine(@"lazyFieldInitializerSingleton = " + lazyFieldInitializerSingleton);
            Console.WriteLine(@"lazyFieldInitializerSingleton.GetHashCode() = " + lazyFieldInitializerSingleton.GetHashCode());
            lazyFieldInitializerSingleton.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var fieldBasedSingleton = ClassFieldBasedSingleton.Instance;
            Console.WriteLine(@"fieldBasedSingleton = " + fieldBasedSingleton);
            Console.WriteLine(@"fieldBasedSingleton.GetHashCode() = " + fieldBasedSingleton.GetHashCode());
            fieldBasedSingleton.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"Press Enter to close.");
            Console.ReadLine();
        }
    }
}
