using System.Collections.Generic;
using System.Threading.Tasks;
using UsersAndCars.Entities;

namespace UsersAndCars.Services.Plaques.Contracts
{
    public interface PlaqueRepository
    {
        List<GetPlaqueDto> GetAll();
        GetPlaqueDto GetPlaqueById(int id);
        void Create(Plaque plaque);
        void Update(int id, Plaque dto);
        void Delete(int id);

    }
}
