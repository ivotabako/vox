using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VM
{
    public class DepartmentVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //Assume each employee is in the format: 'LastName, FirstName'
        public List<string> Employees { get; set; }
    }
}
