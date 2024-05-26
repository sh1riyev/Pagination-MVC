using System;
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Services
{
	public class SliderService :ISliderService
	{
        private readonly AppDbContext _context;
		public SliderService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            return await _context.Sliders.Where(m => !m.IsDeleted).ToListAsync();
        }

        public async Task<SliderInfo> GetInfoASync()
        {
            return await _context.SliderInfo.Where(m => !m.IsDeleted).FirstOrDefaultAsync();
        }
    }
}

