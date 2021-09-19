using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Model
{
    public class InternalEmployee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public InternalDepartment Department { get; set; }
        public int InternalId { get; set; }
    }
}
