using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersAndCars.Entities;
using UsersAndCars.Services.Plaques.Contracts;

namespace UsersAndCars.Persistence.EF.Plaques
{
    public class EFPlaqueRepository : PlaqueRepository
    {

        private readonly DbSet<Plaque> _plaques;

        public EFPlaqueRepository(UsersAndCarsDbContext context)
        {
            _plaques = context.Set<Plaque>();
        }
        public List<GetPlaqueDto> GetAll()
        {
            return _plaques
                .Select(_ => new GetPlaqueDto
                {
                    Id = _.Id,
                    LeftNum = _.LeftNum,
                    RightNum = _.RightNum,
                    CityNum = _.CityNum,
                    Letter = _.Letter
                }).ToList();
        }

        public GetPlaqueDto GetPlaqueById(int id)
        {
            return _plaques.Select(_ => new GetPlaqueDto
            {
                LeftNum = _.LeftNum,
                RightNum = _.RightNum,
                CityNum = _.CityNum,
                Letter = _.Letter
            }).FirstOrDefault(_ => _.Id == id);
        }

        public void Create(Plaque plaque)
        {
            _plaques.Add(plaque);
        }

        public void Update(int id, Plaque dto)
        {
        }

        public void Delete(int id)
        {
            var plaque = _plaques
                .FirstOrDefault(_ => _.Id == id);
            
            _plaques.Remove(plaque);

        }
    }
}
