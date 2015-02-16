using System;
using RentABookPlanner.DAL;

namespace RentABookPlanner.Services
{
    public class EmployeeReader : IReader<Employee>
    {
    
        public Employee Read()
        {
            Console.WriteLine("--- Add employee ---");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Location:");
            string location = Console.ReadLine();

            var employee = new Employee
            {
                Name = name,
                Location = new Location(location),
                BirthDate = DateTime.Now,
                EmploymentDate = DateTime.Now
            };

            return employee;
        }
    }
}
