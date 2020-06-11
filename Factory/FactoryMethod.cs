using System;

namespace Factory
{
    internal abstract class House
    {
        public string Address { get; set; }
        public House(string address)
        {
            Address = address;
        }
    }

    internal class PanelHouse : House
    {
        public PanelHouse(string address) : base(address)
        {
            Console.WriteLine($"Panel house '{Address}' is builded.");
        }
    }

    internal class WoodHouse : House
    {
        public WoodHouse(string address) : base(address)
        {
            Console.WriteLine($"Wood house '{Address}' is builded.");
        }
    }

    internal abstract class Developer
    {
        public Developer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        abstract public House Create(string address);
    }

    internal class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name) : base(name)
        {
            Console.WriteLine($"Panel developer '{Name}'.");
        }

        public override House Create(string address)
        {
            return new PanelHouse(address);
        }
    }

    internal class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name) : base(name)
        {
            Console.WriteLine($"Wood developer '{Name}'.");
        }

        public override House Create(string address)
        {
            return new WoodHouse(address);
        }
    }
}
