using System;

namespace RentABookPlanner.DAL
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Location Location { get; set; }

        public  Employee()
        {
            Id = Guid.NewGuid();
        }

        public Employee(string name, DateTime birthDate, DateTime employmentDate, Location location)
        {
            Id = Guid.NewGuid();
            Name = name;
            BirthDate = birthDate;
            EmploymentDate = employmentDate;
            Location = location;
        }
    }
}
