using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsersAndCars.Services.Cars.Contracts;

namespace UsersAndCars.RestAPI.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarService _service;

        public CarsController(CarService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add(AddCarDto dto)
        {
            _service.Create(dto);
        }

        [HttpGet]
        public List<GetCarDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public GetCarDto GetById(int id)
        {
            return _service.GetCarById(id);
        }
        
        [HttpPut("{id}")]
        public void Update([FromRoute]int id,[FromBody] UpdateCarDto dto)
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
