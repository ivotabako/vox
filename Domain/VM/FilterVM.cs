using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VM
{
    public class FilterVM
    {
        public List<string> IncludedDepartments { get; set; }
        public List<string> ExcludedDepartments { get; set; }
        public List<string> IncludedEmployees { get; set; }
        public List<string> ExcludedEmployees { get; set; }
    }
}
