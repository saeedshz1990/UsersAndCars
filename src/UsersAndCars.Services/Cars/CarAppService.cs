using System.Collections.Generic;
using UsersAndCars.Entities;
using UsersAndCars.Infrastructure.Application;
using UsersAndCars.Services.Cars.Contracts;
using UsersAndCars.Services.Cars.Exceptions;

namespace UsersAndCars.Services.Cars
{
    public class CarAppService : CarService
    {
        private readonly CarRepository _carRepository;
        private readonly UnitOfWork _unitOfWork;

        public CarAppService(CarRepository carRepository, UnitOfWork unitOfWork)
        {
            _carRepository = carRepository;
            _unitOfWork = unitOfWork;
        }

        public List<GetCarDto> GetAll()
        {
            return _carRepository.GetAll();
        }

        public GetCarDto GetCarById(int id)
        {
            return _carRepository.GetCarById(id);
        }

        public void Create(AddCarDto dto)
        {
            var car = new Car
            {
                Name = dto.Name,
                Model = dto.Model,
                EngNumber = dto.EngNumber,
                ChassisNumber = dto.ChassisNumber,
                Color = dto.Color
            };
            
            _carRepository.Create(car);
            _unitOfWork.Commit();
        }

        public void Update(int id, UpdateCarDto dto)
        {
            var car = _carRepository.GetCarById(id);
            if (car != null)
            {
                car.Name = dto.Name;
                car.Model = dto.Model;
                car.Color = dto.Color;
                car.EngNumber = dto.EngNumber;
                car.ChassisNumber = dto.ChassisNumber;

                _unitOfWork.Commit();
            }
            else
            {
                throw new CarNotExistsException();
            }
        }

        public void Delete(int id)
        {
            var car = _carRepository.GetCarById(id);

            if (car != null)
            {
                _carRepository.Delete(id);
                _unitOfWork.Commit();
            }
            else
            {
                throw new CarNotFoundException();
            }
        }
    }
}
