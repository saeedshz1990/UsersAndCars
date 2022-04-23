using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsersAndCars.Services.Plaques.Contracts;

namespace UsersAndCars.RestAPI.Controllers
{
    [Route("api/plaques")]
    [ApiController]
    public class PlaquesController : ControllerBase
    {
        private readonly PlaqueService _service;

        public PlaquesController(PlaqueService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddPlaqueDto dto)
        {
            _service.Create(dto);
        }

        [HttpGet]
        public List<GetPlaqueDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public GetPlaqueDto GetById(int id)
        {
            return _service.GetPlaqueById(id);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute]int id, [FromBody]UpdatePlaqueDto dto)
        {
            _service.Update(id, dto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

    }
}
