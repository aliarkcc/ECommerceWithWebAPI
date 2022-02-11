using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete.BaseEntities;
using Entities.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            User user = new User()
            {
                FirstName = userAddDto.FirstName,
                LastName = userAddDto.LastName,
                Address = userAddDto.Address,
                CreatedUserId = 1,
                DateOfBirth = userAddDto.DateOfBirth,
                Password = userAddDto.Password,
                Email = userAddDto.Email,
                UserName = userAddDto.UserName,
                CreatedDate = DateTime.Now,
                Gender = userAddDto.Gender
            };
            var userAdd = await _userDal.AddAsync(user);

            UserDto userDto = new UserDto()
            {
                UserName = userAdd.UserName,
                Address = userAdd.Address,
                DateOfBirth = userAdd.DateOfBirth,
                Email = userAdd.Email,
                FirstName = userAdd.FirstName,
                LastName = userAdd.LastName,
                Id = userAdd.Id,
                Gender = userAdd.Gender
            };

            return userDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDal.DeleteAsync(id);
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user= await _userDal.GetAsync(x=>x.Id==id);
            UserDto userDto = new UserDto()
            {
                UserName = user.UserName,
                LastName = user.UserName,
                Gender = user.Gender,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                FirstName = user.FirstName,
                Email = user.Email,
                Id = user.Id
            };
            return userDto;
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDetailDtos = new List<UserDetailDto>();
            var response =await _userDal.GetListAsync();
            foreach (var item in response.ToList())
            {
                userDetailDtos.Add(new UserDetailDto()
                {
                    FirstName = item.FirstName,
                    Address = item.Address,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    Gender = item.Gender == true ? "Erkek" : "Kadın",
                    LastName = item.LastName,
                    UserName = item.UserName
                });
            }
            return userDetailDtos;
        }

        public async Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser =await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);

            User user = new User()
            {
                UserName = userUpdateDto.UserName,
                Address = userUpdateDto.Address,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Email = userUpdateDto.Email,
                LastName = userUpdateDto.LastName,
                FirstName = userUpdateDto.FirstName,
                Gender = userUpdateDto.Gender,
                Id = userUpdateDto.Id,
                UpdatedDate = DateTime.Now,
                UpdatedUserId = 1,
                Password = userUpdateDto.Passwod,
                CreatedDate=getUser.CreatedDate,
                CreatedUserId=getUser.CreatedUserId,

            };
            var userUpdate =await _userDal.UpdateAsync(user);
            UserUpdateDto userUpdateDto1 = new UserUpdateDto()
            {
                Address = userUpdate.Address,
                DateOfBirth = userUpdate.DateOfBirth,
                Email = userUpdate.Email,
                Gender = userUpdate.Gender,
                FirstName = userUpdate.FirstName,
                LastName = userUpdate.LastName,
                Id = userUpdate.Id,
                Passwod = userUpdate.Password,
                UserName = userUpdate.UserName
            };
            return userUpdateDto1;
        }
    }
}
