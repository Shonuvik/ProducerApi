using System;
using Microsoft.AspNetCore.Mvc;

namespace ProducerFiap.Controllers
{
	[ApiController]
	[Route("{controller}/v1")]
	public class UserController : ControllerBase
	{
		public UserController()
		{
		}
	}
}

