using System;
using ProducerFiap.Models;

namespace ProducerFiap.ExternalServices.Interfaces
{
	public interface IConnectionFactoryMQ
	{
		void PublishMessage(User user);
	}
}

