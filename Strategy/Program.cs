using System;
using System.Collections.Generic;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---            Examples of program development patterns            ---");
            Console.WriteLine(@"---                            Strategy                            ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var listNames = new List<string>() {
                "Orlando", "Rod", "John", "Ben", "Erich",
                "Eddie", "Oscar", "Jason", "Rocky", "Rey" };

            // Use functor
            UseFunctor(listNames);

            Console.WriteLine(@"----------------------------------------------------------------------");
            
            // Use delegate
            UseDelegate(listNames);

            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"Press Enter to close.");
            Console.ReadLine();
        }

        static void UseFunctor(List<string> listNames)
        {
            Console.WriteLine(@"Use functor.");

            var listEmployees = new List<ClassEmployee>();

            var i = 10;
            foreach (var name  in listNames)
            {
                var employee = new ClassEmployee(i, name);
                Console.WriteLine(employee.ToString());
                listEmployees.Add(employee);
                i--;
            }

            Console.WriteLine(@"listEmployees.Sort(new ClassEmployeeByIdComparer());");
            listEmployees.Sort(new ClassEmployeeByIdComparer());

            foreach (var item in listEmployees)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void UseDelegate(List<string> listNames)
        {
            Console.WriteLine(@"Use delegate.");

            var listEmployees = new List<ClassEmployee>();

            var i = 10;
            foreach (var name in listNames)
            {
                var employee = new ClassEmployee(i, name);
                Console.WriteLine(employee.ToString());
                listEmployees.Add(employee);
                i--;
            }

            Console.WriteLine(@"listEmployees.Sort((x, y) => x.Name.CompareTo(y.Name));");
            listEmployees.Sort((x, y) => x.Id.CompareTo(y.Id));

            foreach (var item in listEmployees)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
