using System;

namespace SingletonLazy
{
    public sealed class ClassLazySingleton
    {
        private static readonly Lazy<ClassLazySingleton> _instance = new Lazy<ClassLazySingleton>(() => new ClassLazySingleton());

        public static ClassLazySingleton Instance => _instance.Value;

#pragma warning disable CS0628 // The new protected member is declared in a sealed class
        private ClassLazySingleton() { }
#pragma warning restore CS0628 // The new protected member is declared in a sealed class

        public static void SomeStaticMethod()
        {
            Console.WriteLine(@"call public static void SomeStaticMethod()");
        }
    }
}
