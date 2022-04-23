using System.Collections.Generic;
using UsersAndCars.Entities;
using UsersAndCars.Infrastructure.Application;
using UsersAndCars.Services.Plaques.Contracts;
using UsersAndCars.Services.Plaques.Exceptions;

namespace UsersAndCars.Services.Plaques
{
    public class PlaqueAppService : PlaqueService
    {
        private readonly PlaqueRepository _plaqueRepository;
        private readonly UnitOfWork _unitOfWork;
        public PlaqueAppService(PlaqueRepository plaqueRepository, UnitOfWork unitOfWork)
        {
            _plaqueRepository = plaqueRepository;
            _unitOfWork = unitOfWork;
        }

        public List<GetPlaqueDto> GetAll()
        {
            return _plaqueRepository.GetAll();
        }

        public GetPlaqueDto GetPlaqueById(int id)
        {
            var plaque = _plaqueRepository.GetPlaqueById(id);

            if (plaque == null)
            {
                throw new PlaqueNotExistsException();
            }

            return plaque;
        }

        public void Create(AddPlaqueDto dto)
        {
            var plaque = new Plaque
            {
                CityNum = dto.CityNum,
                LeftNum = dto.LeftNum,
                RightNum = dto.RightNum,
                Letter = dto.Letter,
            };

            _plaqueRepository.Create(plaque);
            _unitOfWork.Commit();
        }

        public void Update(int id, UpdatePlaqueDto dto)
        {
            var plaque = _plaqueRepository.GetPlaqueById(id);

            if (plaque == null)
            {
                throw new PlaqueNotFoundException();
            }

            plaque.CityNum = dto.CityNum;
            plaque.LeftNum = dto.LeftNum;
            plaque.RightNum = dto.RightNum;
            plaque.Letter = dto.Letter;
            
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            var plaque = _plaqueRepository.GetPlaqueById(id);
            if (plaque!=null)
            {
                _plaqueRepository.Delete(id);
                _unitOfWork.Commit();
            }
            else
            {
                throw new PlaqueNotExistsException();
            }
        }
    }
}
