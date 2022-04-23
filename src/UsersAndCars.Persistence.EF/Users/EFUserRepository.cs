using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UsersAndCars.Entities;
using UsersAndCars.Services.Users.Contracts;

namespace UsersAndCars.Persistence.EF.Users
{
    public class EFUserRepository : UserRepository
    {
        private readonly DbSet<User> _users;
        public EFUserRepository(UsersAndCarsDbContext context)
        {
            _users = context.Set<User>();
        }

        public List<GetUserDto> GetAll()
        {
            return _users.Select(_ => new GetUserDto
            {
                Id = _.Id,
                Name = _.Name,
                Family = _.Family,
                NationalCode = _.NationalCode,
            }).ToList();
        }

        public GetUserDto GetUserById(int id)
        {
            return _users
                .Select(_ => new GetUserDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    Family = _.Family,
                    NationalCode = _.NationalCode,
                }).FirstOrDefault(_ => _.Id == id);

        }

        public void Create(User user)
        {
            _users.Add(user);
        }

        public void Update(int id, User dto)
        {

        }

        public void Delete(int id)
        {
            var user = _users
                .FirstOrDefault(_ => _.Id == id);

            _users.Remove(user);
        }

        public bool IsNationalCodeExist(string nationalCode)
        {
            return _users
                .Any(_ => _.NationalCode == nationalCode);
        }
    }
}
