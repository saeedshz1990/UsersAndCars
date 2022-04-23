using System.Collections.Generic;
using UsersAndCars.Entities;
using UsersAndCars.Infrastructure.Application;
using UsersAndCars.Services.Users.Contracts;
using UsersAndCars.Services.Users.Exceptions;

namespace UsersAndCars.Services.Users
{
    public class UserAppService : UserService
    {
        private readonly UserRepository _userRepository;
        private readonly UnitOfWork _unitOfWork;

        public UserAppService(UserRepository userRepository, UnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public List<GetUserDto> GetAll()
        {
            return _userRepository.GetAll();
        }

        public GetUserDto GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }

        public void Create(AddUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Family = dto.Family,
                NationalCode = dto.NationalCode,
            };

            var isUserExsist = _userRepository
                .IsNationalCodeExist(dto.NationalCode);

            if (isUserExsist == false)
            {
                _userRepository.Create(user);
                _unitOfWork.Commit();
            }
            else
            {
                throw new RepeatedNationalCodeException();
            }
        }

        public void Update(int id, UpdateUserDto dto)
        {
            var isUserExsist = _userRepository
                .IsNationalCodeExist(dto.NationalCode);

            var user = _userRepository.GetUserById(id);

            if (isUserExsist == true)
            {
                throw new NationalCodeCannotRepeatedAgainException();
            }
            else
            {
                user.Name = dto.Name;
                user.Family = dto.Family;
                user.NationalCode = dto.NationalCode;

                _unitOfWork.Commit();
            }
        }

        public void Delete(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user != null)
            {
                _userRepository.Delete(id);
                _unitOfWork.Commit();
            }
            else
            {
                throw new UserNotFoundException();
            }
        }
    }
}
