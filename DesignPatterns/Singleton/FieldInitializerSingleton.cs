using System;

namespace DesignPatterns.Singleton
{
    internal sealed class FieldInitializerSingleton
    {
        private static readonly FieldInitializerSingleton _instance = new FieldInitializerSingleton();

        private FieldInitializerSingleton() { }

        static FieldInitializerSingleton() { }

        public static FieldInitializerSingleton Instance => _instance;

        public void SomeNonStaticMethod()
        {
            Console.WriteLine(@"call public void SomeNonStaticMethod()");
        }
    }
}
