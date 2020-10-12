using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using DesignPatterns.Factory;
using DesignPatterns.Singleton;
using DesignPatterns.Strategy;

namespace DesignPatterns
{
    internal static class Program
    {
        #region Main methods

        private static void Main()
        {
            var numberMenu = -1;
            while (numberMenu != 0)
            {
                PrintCaption();
                try
                {
                    numberMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    numberMenu = -1;
                }

                Console.WriteLine();
                PrintSwitch(numberMenu);
            }
        }

        private static void PrintCaption()
        {
            Console.Clear();
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine("0. Exit from console.");
            Console.WriteLine("11. Abstract factory.");
            Console.WriteLine("12. Factory method.");
            Console.WriteLine("21. Lazy singleton.");
            Console.WriteLine("22. Double check lock singleton.");
            Console.WriteLine("23. Field initializer singleton.");
            Console.WriteLine("31. Strategy.");
            Console.WriteLine("41. IDisposable textReader without secure.");
            Console.WriteLine("42. IDisposable textReader with secure.");
            Console.WriteLine("43. IDisposable textReader with using.");
            Console.WriteLine("44. IDisposable textReader with class.");
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.Write("Type switch: ");
        }

        private static void PrintSwitch(int numberMenu)
        {
            Console.Clear();
            var isPrintMenu = false;
            switch (numberMenu)
            {
                case 11:
                    isPrintMenu = true;
                    PrintAbstractFactory();
                    break;
                case 12:
                    isPrintMenu = true;
                    PrintFactoryMethod();
                    break;
                case 21:
                    isPrintMenu = true;
                    PrintSingletonLazy();
                    break;
                case 22:
                    isPrintMenu = true;
                    PrintSingletonDoubleCheck();
                    break;
                case 23:
                    isPrintMenu = true;
                    PrintSingletonFieldInitializer();
                    break;
                case 31:
                    isPrintMenu = true;
                    PrintStrategy();
                    break;
                case 41:
                    isPrintMenu = true;
                    PrintIDisposableTextReaderWithoutSecure();
                    break;
                case 42:
                    isPrintMenu = true;
                    PrintIDisposableTextReaderWithSecure();
                    break;
                case 43:
                    isPrintMenu = true;
                    PrintIDisposableTextReaderWithUsing();
                    break;
                case 44:
                    isPrintMenu = true;
                    PrintIDisposableTextReaderWithClass();
                    break;
            }
            if (isPrintMenu)
            {
                Console.WriteLine(@"----------------------------------------------------------------------");
                Console.Write("Type any key to return in main menu.");
                Console.ReadKey();
            }
        }

        #endregion

        #region Factory

        private static void PrintAbstractFactory()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---                        Abstract factory                        ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            string factoryName = PrintAbstractFactory_GetFactoryName(EnumDbProvider.SqlClient);
            var providerFactory = DbProviderFactories.GetFactory(factoryName);
            var authentication = new Authentication();
            var abstractFactory = new AbstractFactory(providerFactory, @"LOCALHOST\SQL2019", "SAMPLE", authentication, "DesignPatterns");
            var query = "SELECT * FROM [HUMAN] WHERE [ID] > @ID ORDER BY [ID]";
            
            Console.WriteLine($@"string {nameof(factoryName)} = {nameof(PrintAbstractFactory_GetFactoryName)}({nameof(EnumDbProvider)}.{factoryName});");
            Console.WriteLine($@"var {nameof(providerFactory)} = DbProviderFactories.GetFactory({nameof(factoryName)});");
            Console.WriteLine($@"var {nameof(authentication)} = new Authentication();");
            Console.WriteLine($@"var {nameof(abstractFactory)} = new {nameof(AbstractFactory)}(" + 
                $@"{nameof(providerFactory)}, ""{abstractFactory.DataSource}"", ""{abstractFactory.InitialCatalog}"", {nameof(authentication)});");

            Console.WriteLine($@"var query = ""{query}""");
            Console.WriteLine(@"----------------------------------------------------------------------");
            var records = abstractFactory.SelectData(query,
                new Collection<(string, object)>() { ("ID", 10) },
                new Collection<string>() { "ID", "FIRSTNAME", "LASTNAME", "SURNAME" });
            foreach (var record in records)
            {
                Console.WriteLine(string.Join("; ", record));
            }
        }

        private static string PrintAbstractFactory_GetFactoryName(EnumDbProvider dbProvider)
        {
            switch (dbProvider)
            {
                case EnumDbProvider.Odbc:
                    return "System.Data.Odbc";
                case EnumDbProvider.OleDb:
                    return "System.Data.OleDb";
                case EnumDbProvider.OracleClient:
                    return "System.Data.OracleClient";
                case EnumDbProvider.SqlClient:
                    return "System.Data.SqlClient";
                default:
                    throw new ArgumentOutOfRangeException(nameof(dbProvider), dbProvider, null);
            }
        }

        private static void PrintFactoryMethod()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---                         Factory method                         ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var panelDev = new PanelDeveloper("First company");
            panelDev.Create("Street few, 1");
            panelDev.Create("Street new, 2");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var woodDev = new WoodDeveloper("Second company");
            woodDev.Create("Street few, 3");
            woodDev.Create("Street new, 4");
        }

        #endregion

        #region Singleton

        private static void PrintSingletonLazy()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---                         Lazy singleton                         ---");
            Console.WriteLine(@"----------------------------------------------------------------------");


            var lazySingleton = LazySingletonWithStaticMethod.Instance;
            Console.WriteLine($@"{nameof(lazySingleton)} = {nameof(LazySingletonWithStaticMethod)}.Instance");
            Console.WriteLine($@"{nameof(lazySingleton)}.GetHashCode() = {lazySingleton.GetHashCode()}");
            LazySingletonWithStaticMethod.SomeStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var lazySingleton1 = LazySingleton.Instance;
            Console.WriteLine($@"{nameof(lazySingleton1)} = {nameof(LazySingleton)}.Instance");
            Console.WriteLine($@"{nameof(lazySingleton1)}.GetHashCode() = " + lazySingleton1.GetHashCode());
            lazySingleton1.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var lazySingleton2 = LazySingleton.Instance;
            Console.WriteLine($@"{nameof(lazySingleton2)} = {nameof(LazySingleton)}.");
            Console.WriteLine($@"{nameof(lazySingleton2)}.GetHashCode() = " + lazySingleton2.GetHashCode());
            lazySingleton2.SomeNonStaticMethod();
        }

        private static void PrintSingletonDoubleCheck()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---                   Double check lock singleton                  ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var doubleCheckedLockSingleton1 = DoubleCheckedLockSingleton.Instance;
            Console.WriteLine($@"{nameof(doubleCheckedLockSingleton1)} = {nameof(DoubleCheckedLockSingleton)}.Instance");
            Console.WriteLine($@"{nameof(doubleCheckedLockSingleton1)}.GetHashCode() = " + doubleCheckedLockSingleton1.GetHashCode());
            doubleCheckedLockSingleton1.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var doubleCheckedLockSingleton2 = DoubleCheckedLockSingleton.Instance;
            Console.WriteLine($@"{nameof(doubleCheckedLockSingleton2)} = {nameof(DoubleCheckedLockSingleton)}.Instance");
            Console.WriteLine($@"{nameof(doubleCheckedLockSingleton2)}.GetHashCode() = {doubleCheckedLockSingleton2.GetHashCode()}");
            doubleCheckedLockSingleton2.SomeNonStaticMethod();
        }

        private static void PrintSingletonFieldInitializer()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---                   Field initializer singleton                  ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var fieldInitializerSingleton = FieldInitializerSingleton.Instance;
            Console.WriteLine(@"fieldInitializerSingleton = " + fieldInitializerSingleton);
            Console.WriteLine(@"fieldInitializerSingleton.GetHashCode() = " + fieldInitializerSingleton.GetHashCode());
            fieldInitializerSingleton.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var lazyFieldInitializerSingleton = LazyFieldInitializerSingleton.Instance;
            Console.WriteLine(@"lazyFieldInitializerSingleton = " + lazyFieldInitializerSingleton);
            Console.WriteLine(@"lazyFieldInitializerSingleton.GetHashCode() = " + lazyFieldInitializerSingleton.GetHashCode());
            lazyFieldInitializerSingleton.SomeNonStaticMethod();
            Console.WriteLine(@"----------------------------------------------------------------------");

            var fieldBasedSingleton = FieldBasedSingleton.Instance;
            Console.WriteLine(@"fieldBasedSingleton = " + fieldBasedSingleton);
            Console.WriteLine(@"fieldBasedSingleton.GetHashCode() = " + fieldBasedSingleton.GetHashCode());
            fieldBasedSingleton.SomeNonStaticMethod();
        }

        #endregion

        #region Strategy

        private static void PrintStrategy()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---                            Strategy                            ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var listNames = new List<string>() {
                "Orlando", "Rod", "John", "Ben", "Erich", "Eddie", "Oscar", "Jason", "Rocky", "Rey" };

            // Use functor
            PrintStrategy_UseFunctor(listNames);

            Console.WriteLine(@"----------------------------------------------------------------------");

            // Use delegate
            PrintStrategy_UseDelegate(listNames);
        }

        private static void PrintStrategy_UseFunctor(IEnumerable<string> listNames)
        {
            Console.WriteLine(@"Use functor.");

            var listEmployees = new List<Employee>();

            var i = 10;
            foreach (var name in listNames)
            {
                var employee = new Employee(i, name);
                Console.WriteLine(employee.ToString());
                listEmployees.Add(employee);
                i--;
            }

            Console.WriteLine($@"listEmployees.Sort(new {nameof(EmployeeByIdComparer)}());");
            listEmployees.Sort(new EmployeeByIdComparer());

            foreach (var item in listEmployees)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void PrintStrategy_UseDelegate(IEnumerable<string> listNames)
        {
            Console.WriteLine(@"Use delegate.");

            var listEmployees = new List<Employee>();

            var i = 10;
            foreach (var name in listNames)
            {
                var employee = new Employee(i, name);
                Console.WriteLine(employee.ToString());
                listEmployees.Add(employee);
                i--;
            }

            Console.WriteLine(@"listEmployees.Sort((x, y) => x.Id.CompareTo(y.Id));");
            listEmployees.Sort((x, y) => x.Id.CompareTo(y.Id));

            foreach (var item in listEmployees)
            {
                Console.WriteLine(item.ToString());
            }
        }

        #endregion

        #region IDisposable

        private static void PrintIDisposableTextReaderWithoutSecure()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---               IDisposable textReader without secure            ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var listNames = new List<string>() {
                "Orlando", "Rod", "John", "Ben", "Erich", "Eddie", "Oscar", "Jason", "Rocky", "Rey" };

            Console.WriteLine(@"----------------------------------------------------------------------");
        }

        private static void PrintIDisposableTextReaderWithSecure()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---                IDisposable textReader with secure              ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var listNames = new List<string>() {
                "Orlando", "Rod", "John", "Ben", "Erich", "Eddie", "Oscar", "Jason", "Rocky", "Rey" };

            Console.WriteLine(@"----------------------------------------------------------------------");
        }

        private static void PrintIDisposableTextReaderWithUsing()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---                 IDisposable textReader with using              ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var listNames = new List<string>() {
                "Orlando", "Rod", "John", "Ben", "Erich", "Eddie", "Oscar", "Jason", "Rocky", "Rey" };

            Console.WriteLine(@"----------------------------------------------------------------------");
        }

        private static void PrintIDisposableTextReaderWithClass()
        {
            Console.WriteLine(@"----------------------------------------------------------------------");
            Console.WriteLine(@"---                   Examples of design patterns                  ---");
            Console.WriteLine(@"---                 IDisposable textReader with class              ---");
            Console.WriteLine(@"----------------------------------------------------------------------");

            var listNames = new List<string>() {
                "Orlando", "Rod", "John", "Ben", "Erich", "Eddie", "Oscar", "Jason", "Rocky", "Rey" };

            Console.WriteLine(@"----------------------------------------------------------------------");
        }

        #endregion
    }
}
