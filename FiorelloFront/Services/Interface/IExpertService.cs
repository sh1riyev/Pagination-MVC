using System;
using FiorelloFront.Models;

namespace FiorelloFront.Services.Interface
{
	public interface IExpertService
	{
		public Task<IEnumerable<Experts>> GetAllAsync();
	}
}

