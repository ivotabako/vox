using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Employee
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Employee(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
