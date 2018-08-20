using System;

namespace SingletonLazy
{
    public sealed class ClassLazySingleton
    {
        private static readonly Lazy<ClassLazySingleton> _instance = new Lazy<ClassLazySingleton>(() => new ClassLazySingleton());

        public static ClassLazySingleton Instance => _instance.Value;

        private ClassLazySingleton() { }

        public void SomeNonStaticMethod()
        {
            Console.WriteLine(@"call public void SomeNonStaticMethod()");
        }
    }
}
