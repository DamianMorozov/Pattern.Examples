using System;

namespace DesignPatterns.Singleton
{
    internal sealed class LazyFieldInitializerSingleton
    {
        private static class SingletonHolder
        {
            public static readonly LazyFieldInitializerSingleton _instance = new LazyFieldInitializerSingleton();
        }

        private LazyFieldInitializerSingleton() { }

        public static LazyFieldInitializerSingleton Instance => SingletonHolder._instance;

        public void SomeNonStaticMethod()
        {
            Console.WriteLine(@"call public void SomeNonStaticMethod()");
        }
    }
}
