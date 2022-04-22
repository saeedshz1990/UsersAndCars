namespace UsersAndCars.Services.Plaques.Contracts
{
    public class GetPlaqueDto
    {
        public int Id { get; set; }
        public int LeftNum { get; set; }
        public char Letter { get; set; }
        public int RightNum { get; set; }
        public int CityNum { get; set; }
    }
}
