using System;

namespace SingletonFieldInitializer
{
    public sealed class ClassFieldInitializerSingleton
    {
        private static readonly ClassFieldInitializerSingleton _instance = new ClassFieldInitializerSingleton();

        private ClassFieldInitializerSingleton() { }

        static ClassFieldInitializerSingleton() { }

        public static ClassFieldInitializerSingleton Instance { get { return _instance; } }

        public void SomeNonStaticMethod()
        {
            Console.WriteLine(@"call public void SomeNonStaticMethod()");
        }
    }
}
