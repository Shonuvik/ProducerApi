using System;
using ProducerFiap.Controllers.Dtos;
using ProducerFiap.ExternalServices.Interfaces;
using ProducerFiap.Models;
using ProducerFiap.Services.Interfaces;

namespace ProducerFiap.Services
{
    public class UserService : IUserService
    {
        private readonly IConnectionFactoryMQ _connectionFactoryMQ;

        public UserService(IConnectionFactoryMQ connectionFactoryMQ)
        {
            _connectionFactoryMQ = connectionFactoryMQ;
        }

        public async Task PostMessagQueue(UserDto user)
            => await Task.Run(() => _connectionFactoryMQ.PublishMessage(ParseToEntity(user)));


        private User ParseToEntity(UserDto userDto)
        {
            return new User(userDto.UserName, userDto.Password, userDto.Email);
        }
    }
}

