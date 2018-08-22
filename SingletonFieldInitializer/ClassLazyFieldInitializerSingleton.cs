using System;

namespace SingletonFieldInitializer
{
    public sealed class ClassLazyFieldInitializerSingleton
    {
        private static class SingletonHolder
        {
            public static readonly ClassLazyFieldInitializerSingleton _instance = new ClassLazyFieldInitializerSingleton();
        }

        private ClassLazyFieldInitializerSingleton() { }

        public static ClassLazyFieldInitializerSingleton Instance { get { return SingletonHolder._instance; } }

        public void SomeNonStaticMethod()
        {
            Console.WriteLine(@"call public void SomeNonStaticMethod()");
        }
    }
}
