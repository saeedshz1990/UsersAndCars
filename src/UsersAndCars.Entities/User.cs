using System;
using System.Collections.Generic;

namespace UsersAndCars.Entities
{
    public class User :EntityBase
    {
        public User()
        {
            Plaques = new HashSet<Plaque>();
        }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        
        public int PlaqueId { get; set; }
        public HashSet<Plaque> Plaques { get; set; }
    }
}
