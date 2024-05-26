using System;
using FiorelloFront.Data;
using FiorelloFront.Models;

namespace FiorelloFront.Services.Interface
{
	public interface ISocialService
	{
        public Task<IEnumerable<Social>> GetAllSocial();
    }
}

