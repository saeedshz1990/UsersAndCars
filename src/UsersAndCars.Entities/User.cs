using System;

namespace UsersAndCars.Entities
{
    public class User :EntityBase
    {
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
