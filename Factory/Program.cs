using System;

namespace Factory
{
    internal class Program
    {
        internal static void Main()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---            Examples of program development patterns            ---");
            Console.WriteLine(@"---                         Factory method                         ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var panelDev = new PanelDeveloper("First company");
            var panelHouse1 = panelDev.Create("Street few, 1");
            var panelHouse2 = panelDev.Create("Street new, 2");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var woodDev = new WoodDeveloper("Second company");
            var woodHouse1 = woodDev.Create("Street few, 3");
            var woodHouse2 = woodDev.Create("Street new, 4");
            Console.WriteLine(@"----------------------------------------------------------------------");

            Console.WriteLine(@"Press Enter to close.");
            Console.ReadLine();
        }
    }
}
