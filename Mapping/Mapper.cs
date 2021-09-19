using Domain.Model;
using Domain.VM;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mapping
{
    public static class Mapper
    {
        public static Department GetDepartment(DepartmentVM vm)
        {
            return new Department(vm.Id, vm.Name, vm.Employees.Select(x => new Employee(x.Split(',')[1].Trim(), x.Split(',')[0].Trim())).ToList());
        }

        public static Department GetDepartment(InternalDepartment internalDepartment)
        {
            var dep = new Department(internalDepartment.Id, internalDepartment.Name, internalDepartment.Employees.Select(e => new Employee(e.Name, e.Surname)).ToList());
            return dep;
        }

        public static InternalDepartment GetInternalDepartment(Department department)
        {
            var intDep = new InternalDepartment();
            intDep.Id = department.Id;
            intDep.Name = department.Name;
            intDep.Employees = new List<InternalEmployee>();
            foreach (var employee in department.Employees ?? new List<Employee>())
            {
                var intEmp = new InternalEmployee();
                intEmp.Department = intDep;
                intEmp.Name = employee.Name;
                intEmp.Surname = employee.Surname;
                intDep.Employees.Add(intEmp);
            }

            return intDep;
        }

        public static InternalEmployee GetInternalEmployee(Employee employee)
        {
            var intEmp = new InternalEmployee();
            intEmp.Name = employee.Name;
            intEmp.Surname = employee.Surname;

            return intEmp;
        }
    }
}
