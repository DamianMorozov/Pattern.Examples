using System;
using System.Collections.Generic;

namespace Strategy
{
    internal class ClassEmployee
    {
        public int Id { get; }
        public string Name { get; }

        public ClassEmployee(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override string ToString()
        {
            return string.Format($@"ID: {Id}. Name: {Name}.");
        }
    }

    internal class ClassEmployeeByIdComparer : IComparer<ClassEmployee>
    {
        public int Compare(ClassEmployee x, ClassEmployee y)
        {
            if (x != null && y != null)
                return x.Id.CompareTo(y.Id);
            return default;
        }
    }
}
