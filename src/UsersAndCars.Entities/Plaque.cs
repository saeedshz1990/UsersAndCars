namespace UsersAndCars.Entities
{
    public class Plaque :EntityBase
    {
        public int LeftNum { get; set; }
        public char Letter { get; set; }
        public int RightNum { get; set; }
        public int CityNum { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int UserId { get; set; }
        public User Users { get; set; }
    }
}
