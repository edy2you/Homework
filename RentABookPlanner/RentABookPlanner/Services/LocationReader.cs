using System;
using RentABookPlanner.DAL;

namespace RentABookPlanner.Services
{
    public class LocationReader
    {
        public Location Read()
        {
            Console.WriteLine("--- Add location ---");
            Console.WriteLine("Name:");
            string name = Console.ReadLine();

            var location = new Location { Name = name };

            return location;
        }
    }
}

