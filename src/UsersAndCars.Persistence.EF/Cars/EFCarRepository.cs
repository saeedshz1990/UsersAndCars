using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersAndCars.Entities;
using UsersAndCars.Services.Cars.Contracts;

namespace UsersAndCars.Persistence.EF.Cars
{
    public class EFCarRepository : CarRepository
    {
        private readonly DbSet<Car> _cars;

        public EFCarRepository(UsersAndCarsDbContext context)
        {
            _cars = context.Set<Car>();

        }

        public List<GetCarDto> GetAll()
        {
            return _cars.Select(_ => new GetCarDto
            {
                Id = _.Id,
                Model = _.Model,
                Color = _.Color,
                Name = _.Name,
                EngNumber = _.EngNumber,
                ChassisNumber = _.ChassisNumber,
            }).ToList();
        }

        public GetCarDto GetCarById(int id)
        {
            return _cars
                .Select(_ => new GetCarDto
                {
                    Model = _.Model,
                    Color = _.Color,
                    Name = _.Name,
                    EngNumber = _.EngNumber,
                    ChassisNumber = _.ChassisNumber,
                }).FirstOrDefault(_ => _.Id == id);
        }

        public void Create(Car car)
        {
            _cars.Add(car);
        }

        public void Update(int id, Car dto)
        {


        }

        public void Delete(int id)
        {
            var car = _cars
                .FirstOrDefault(_ => _.Id == id);

            _cars.Remove(car);


        }
    }
}
