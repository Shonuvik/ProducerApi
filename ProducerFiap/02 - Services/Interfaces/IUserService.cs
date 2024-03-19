using System;
using ProducerFiap.Controllers.Dtos;

namespace ProducerFiap.Services.Interfaces
{
    public interface IUserService
    {
        Task PostMessagQueue(UserDto user);
    }
}

