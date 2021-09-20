using Domain.Model;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    public static class DepartmentRepository
    {
        private static readonly Dictionary<int, InternalDepartment> departments = new Dictionary<int, InternalDepartment>();
        private static int deptIndex = 1;
        private static readonly Dictionary<int, InternalEmployee> employees = new Dictionary<int, InternalEmployee>();

        public static IEnumerable<InternalDepartment> GetAll()
        {
            return departments.Values;
        }

        private static int empIndex = 1;

        public static int Save(InternalDepartment department)
        {
            if (departments.ContainsKey(department.InternalId))
            {
                departments[department.InternalId] = department;
            }
            else
            {
                department.InternalId = deptIndex++;
                departments.Add(department.InternalId, department);
            }

            return department.InternalId;
        }

        public static InternalDepartment GetDepartmentById(Guid id)
        {
            return departments.Values.FirstOrDefault(dep => dep.Id.Equals(id));
        }

        public static int Save(InternalEmployee employee)
        {
            if (employees.ContainsKey(employee.InternalId))
            {
                employees[employee.InternalId] = employee;
            }
            else
            {
                employee.InternalId = empIndex++;
                employees.Add(employee.InternalId, employee);
            }

            return employee.InternalId;
        }

        public static InternalEmployee GetEmployeeByName(string name, string surname)
        {
            return employees.Values.FirstOrDefault(emp => 
            string.Equals(emp.Name, name, StringComparison.CurrentCultureIgnoreCase) && 
            string.Equals(emp.Surname, surname, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
