using System.Collections.Generic;
using System.Threading.Tasks;
using UsersAndCars.Entities;

namespace UsersAndCars.Services.Cars.Contracts
{
    public interface CarRepository
    {
        List<GetCarDto> GetAll();
        GetCarDto GetCarById(int id);
        void Create(Car car);
        void Update(int id, Car dto);
        void Delete(int id);

    }
}
