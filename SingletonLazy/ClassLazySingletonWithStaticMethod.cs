using System;

namespace SingletonLazy
{
    public sealed class ClassLazySingletonWithStaticMethod
    {
        private static readonly Lazy<ClassLazySingletonWithStaticMethod> _instance = new Lazy<ClassLazySingletonWithStaticMethod>(() => new ClassLazySingletonWithStaticMethod());

        public static ClassLazySingletonWithStaticMethod Instance => _instance.Value;

        private ClassLazySingletonWithStaticMethod() { }

        public static void SomeStaticMethod()
        {
            Console.WriteLine(@"call public static void SomeStaticMethod()");
        }
    }
}
