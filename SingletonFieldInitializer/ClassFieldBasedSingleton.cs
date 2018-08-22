using System;

namespace SingletonFieldInitializer
{
    public class ClassFieldBasedSingleton
    {
        public static readonly ClassFieldBasedSingleton Instance = new ClassFieldBasedSingleton();

        public void SomeNonStaticMethod()
        {
            Console.WriteLine(@"call public void SomeNonStaticMethod()");
        }
    }
}
