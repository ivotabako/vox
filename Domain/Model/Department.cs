using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Department
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Employee> Employees { get; private set; }

        public Department(Guid id, string name, List<Employee> employees)
        {
            Id = id;
            Name = name;
            Employees = employees;
        }
    }
}
