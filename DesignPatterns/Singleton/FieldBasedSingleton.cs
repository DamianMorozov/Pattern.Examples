using System;

namespace DesignPatterns.Singleton
{
    internal class FieldBasedSingleton
    {
        public static readonly FieldBasedSingleton Instance = new FieldBasedSingleton();

        public void SomeNonStaticMethod()
        {
            Console.WriteLine(@"call public void SomeNonStaticMethod()");
        }
    }
}
