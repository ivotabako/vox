using Domain.Model;
using Mapping;
using Repository;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class DepartmentService
    {
        public static IEnumerable<Department> GetDepartments()
        {
            IEnumerable<InternalDepartment> intDeps = DepartmentRepository.GetAll();
            var deps = new List<Department>();
            foreach (var intDep in intDeps)
            {
                deps.Add(Mapper.GetDepartment(intDep));
            }

            return deps;
        }

        public static int Post(Department department)
        {
            var deps = DepartmentRepository.GetAll();
            var intDep = Mapper.GetInternalDepartment(department);
            foreach (var dep in deps)
            {
                if (dep.Id.Equals(department.Id))
                {
                    intDep.InternalId = DepartmentRepository.GetById(department.Id)?.InternalId ?? 0;
                }
            }
            int departmentId = DepartmentRepository.Save(intDep);
            foreach (var employee in department.Employees)
            {
                DepartmentRepository.Save(Mapper.GetInternalEmployee(employee));
            }

            return departmentId;
        }
    }
}
