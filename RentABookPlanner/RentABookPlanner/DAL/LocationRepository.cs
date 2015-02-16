using System;
using System.Collections.Generic;
using System.Linq;

namespace RentABookPlanner.DAL
{
    public class LocationRepository
    {
         private readonly List<Location> Locations;

         public LocationRepository()
        {
            Locations = new List<Location>();
        }

        public void Add(Location location)
        {
            Locations.Add(location);
        }

        public Location GetLocationByName(string Name)
        {
            return Locations.First(l => l.Name == Name);
        }

        public void Remove(Guid locationId)
        {
            Locations.RemoveAll(l => l.Id == locationId);
            
        }
    }
}
