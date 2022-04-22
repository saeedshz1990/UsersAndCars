namespace UsersAndCars.Entities
{
    public class Car :EntityBase
    {
        public string Color { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string EngNumber { get; set; }
        public string ChassisNumber { get; set; }
        
        public Plaque Plaque { get; set; }
    }
}
