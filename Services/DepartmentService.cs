using Domain.Model;
using Mapping;
using Repository;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public static class DepartmentService
    {
        public static IEnumerable<Department> GetDepartments()
        {
            return DepartmentRepository.GetAll().Select(intDep => Mapper.GetDepartment(intDep));           
        }

        public static int Post(Department department)
        {
            var deps = DepartmentRepository.GetAll();
            var intDep = Mapper.GetInternalDepartment(department);
            deps
                .Where(dep => dep.Id.Equals(department.Id))
                .Select(d => intDep.InternalId = DepartmentRepository.GetDepartmentById(d.Id)?.InternalId ?? 0);
            
            int departmentId = DepartmentRepository.Save(intDep);
            foreach (var employee in department.Employees)
            {
                int intEmpId = DepartmentRepository.GetEmployeeByName(employee.Name, employee.Surname)?.InternalId ?? 0;
                var intEmp = Mapper.GetInternalEmployee(employee);
                intEmp.InternalId = intEmpId;
                DepartmentRepository.Save(intEmp);
            }

            return departmentId;
        }
    }
}
