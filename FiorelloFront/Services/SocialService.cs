using System;
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Services
{
	public class SocialService :ISocialService
	{
        private readonly AppDbContext _context;
		public SocialService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<IEnumerable<Social>> GetAllSocial()
        {
            return await _context.Socials.ToListAsync();
        }
    }
}

