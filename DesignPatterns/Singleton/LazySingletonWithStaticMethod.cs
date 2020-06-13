using System;

namespace DesignPatterns.Singleton
{
    internal sealed class LazySingletonWithStaticMethod
    {
        private static readonly Lazy<LazySingletonWithStaticMethod> _instance = new Lazy<LazySingletonWithStaticMethod>(() => new LazySingletonWithStaticMethod());

        public static LazySingletonWithStaticMethod Instance => _instance.Value;

        private LazySingletonWithStaticMethod() { }

        public static void SomeStaticMethod()
        {
            Console.WriteLine(@"call public static void SomeStaticMethod()");
        }
    }
}
