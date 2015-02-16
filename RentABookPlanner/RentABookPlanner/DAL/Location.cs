using System;

namespace RentABookPlanner.DAL
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Location()
        {
            Id = Guid.NewGuid();
        }

        public Location(string name)
        {
            Name = name;
        }
    }
}
