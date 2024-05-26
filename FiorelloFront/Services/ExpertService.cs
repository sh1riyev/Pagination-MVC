using System;
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Services
{
	public class ExpertService :IExpertService
	{
        private readonly AppDbContext _context;
		public ExpertService(AppDbContext context)
		{
            _context = context;
		}

        async Task<IEnumerable<Experts>> IExpertService.GetAllAsync()
        {
            return await _context.Experts.Where(m => !m.IsDeleted).ToListAsync();
        }
    }
}

