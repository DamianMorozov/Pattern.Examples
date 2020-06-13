using System;
using System.Collections.Generic;

namespace DesignPatterns.Strategy
{
    internal class Employee
    {
        public int Id { get; }
        public string Name { get; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public override string ToString()
        {
            return string.Format($@"ID: {Id}. Name: {Name}.");
        }
    }

    internal class EmployeeByIdComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x != null && y != null)
                return x.Id.CompareTo(y.Id);
            return default;
        }
    }
}
