using System.Collections.Generic;

namespace UsersAndCars.Services.Users.Contracts
{
    public interface UserService
    {
        List<GetUserDto> GetAll();
        GetUserDto GetUserById(int id);
        void Create(AddUserDto dto);
        void Update(int id, UpdateUserDto dto);
        void Delete(int id);
    }
}
