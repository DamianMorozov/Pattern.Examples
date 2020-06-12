using System;

namespace Factory
{
    internal abstract class House
    {
        protected string Address { get; }

        protected House(string address)
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
        protected Developer(string name)
        {
            Name = name;
        }

        protected string Name { get; }

        public abstract House Create(string address);
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
