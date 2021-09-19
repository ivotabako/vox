using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.VM
{
    public class FilterResultVM
    {
        public List<string> FilteredDepartments { get; set; }
        public List<string> FilteredEmployees { get; set; }
    }
}
