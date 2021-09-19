using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Model
{
    public class InternalDepartment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<InternalEmployee> Employees { get; set; }
        public int InternalId { get; set; }
    }
}
