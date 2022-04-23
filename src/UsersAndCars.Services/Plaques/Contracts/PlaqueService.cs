using System.Collections.Generic;
using UsersAndCars.Entities;

namespace UsersAndCars.Services.Plaques.Contracts
{
    public interface PlaqueService
    {
        List<GetPlaqueDto> GetAll();
        GetPlaqueDto GetPlaqueById(int id);
        void Create(AddPlaqueDto dto);
        void Update(int id, UpdatePlaqueDto dto);
        void Delete(int id);
        
    }
}
