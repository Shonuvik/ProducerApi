using System;
using Microsoft.AspNetCore.Mvc;
using ProducerFiap.Controllers.Dtos;
using ProducerFiap.Services.Interfaces;

namespace ProducerFiap.Controllers
{
	[ApiController]
	[Route("{controller}/v1")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

        public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpPost]
		public async Task<IActionResult> Post(UserDto user)
		{
			await _userService.PostMessagQueue(user);
			return Ok();
		}
	}
}

