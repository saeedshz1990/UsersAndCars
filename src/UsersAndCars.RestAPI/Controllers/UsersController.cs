using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UsersAndCars.Services.Users.Contracts;

namespace UsersAndCars.RestAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }


        [HttpPost]
        public void Add(AddUserDto dto)
        {
            _service.Create(dto);
        }

        [HttpGet]
        public List<GetUserDto> GetAll()
        {
            return _service.GetAll();
        }
        
        [HttpGet("{id}")]
        public GetUserDto GetById(int id)
        {
            return _service.GetUserById(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update([FromRoute]int id,[FromBody] UpdateUserDto dto)
        {
            _service.Update(id, dto);
        }


    }
}
