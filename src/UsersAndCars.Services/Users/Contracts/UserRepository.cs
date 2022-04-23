using System.Collections.Generic;
using System.Threading.Tasks;
using UsersAndCars.Entities;

namespace UsersAndCars.Services.Users.Contracts
{
    public interface UserRepository
    {
        List<GetUserDto> GetAll();
        GetUserDto GetUserById(int id);
        void Create(User user);
        void Update(int id, User dto);
        void Delete(int id);
        bool IsNationalCodeExist(string nationalCode);
    }
}
