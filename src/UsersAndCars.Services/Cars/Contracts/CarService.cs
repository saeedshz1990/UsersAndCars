using System.Collections.Generic;
using UsersAndCars.Entities;

namespace UsersAndCars.Services.Cars.Contracts
{
    public interface CarService
    {
        List<GetCarDto> GetAll();
        GetCarDto GetCarById(int id);
        void Create(AddCarDto dto);
        void Update(int id, UpdateCarDto dto);
        void Delete(int id);
    }
}
