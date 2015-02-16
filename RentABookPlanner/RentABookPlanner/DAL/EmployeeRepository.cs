using System;
using System.Collections.Generic;
using System.Linq;

namespace RentABookPlanner.DAL
{
    public class EmployeeRepository
    {
        private readonly List<Employee> Employees;

        public EmployeeRepository()
        {
            Employees = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            Employees.Add(employee);
        }

        public Employee GetEmployeeByName(string Name)
        {
            return Employees.First(e => e.Name == Name);
        }

        public void Remove(Guid employeeId)
        {
            Employees.RemoveAll(e => e.Id == employeeId);
        }
    }
}
