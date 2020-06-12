using System;

namespace Factory
{
    internal static class Program
    {
        internal static void Main()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---            Examples of program development patterns            ---");
            Console.WriteLine(@"---                         Factory method                         ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var panelDev = new PanelDeveloper("First company");
            panelDev.Create("Street few, 1");
            panelDev.Create("Street new, 2");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var woodDev = new WoodDeveloper("Second company");
            woodDev.Create("Street few, 3");
            woodDev.Create("Street new, 4");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"Press Enter to close.");
            Console.ReadLine();
        }
    }
}
