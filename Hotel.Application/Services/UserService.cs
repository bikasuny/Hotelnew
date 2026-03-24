using AutoMapper;
using Hotel.Application.Dto;
using Hotel.Core.Entities;
using Hotel.Core.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services
{
    public class UserService
    {
        private readonly GenericRepository<User> _userServices;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _map;

        public UserService(GenericRepository<User> userServices, ILogger<UserService> logger, IMapper map)
        {
            _userServices = userServices;
            _logger = logger;
            _map = map;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            _logger.LogInformation("get all user is called");
            var users = await _userServices.GetAllAsync();
            var userMapped = _map.Map<List<UserDto>>(users.Where(i => i.IsActive));
            _logger.LogDebug("db return Users:{@users}", userMapped);
            return userMapped;
        }


        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _userServices.GetByIdAsync(id);
            if (user is null || user.IsActive == false) throw new ArgumentException("user not found");
            var mappedUser = _map.Map<UserDto>(user);
            return mappedUser;
        }

        public async Task AddNewUser(UserDto user)
        {
            _logger.LogDebug("New user: {@user}", user);
            ArgumentNullException.ThrowIfNull(user);
            var maapped = _map.Map<User>(user);
            var suchUser = _userServices.Predicate(i => i.PersonalNumber == user.PersonalNumber);
            if (suchUser)
            {
                _logger.LogInformation("user reject to register becouse such user already exist");
                throw new ArgumentException("user already exist");
            }

            await _userServices.AddAsync(maapped);
        }

        public async Task UpdateUser(UserDto user)
        {
            _logger.LogDebug("Updated user:{@user}", user);
            if (user.Id == 0) throw new ArgumentException("something is wrong please contact devs");

            var mapped = _map.Map<User>(user);
            await _userServices.UpdateAsync(mapped);
        }

        public async Task DeleteUser(int id)
        {
            _logger.LogInformation("Deleted user {id}", id);
            var user = await GetUserById(id);

            var userBase = _map.Map<User>(user);
            if (userBase.IsActive == false) throw new ArgumentException("user already inactive");

            userBase.IsActive = false;
            await _userServices.SaveChanges();

            _logger.LogDebug("Delete  completed User {id}", id);
        }
    }
}
