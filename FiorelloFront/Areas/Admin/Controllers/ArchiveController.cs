using System;
using FiorelloFront.Data;
using FiorelloFront.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ArchiveController : Controller
	{
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;
		public ArchiveController(ICategoryService categoryService, AppDbContext context)
		{
			_categoryService = categoryService;
			_context = context;
		}

		public async Task<IActionResult> CategoryArchive()
		{
			return View(await _categoryService.GetAllArchive());
		}

		[HttpPost]
		public async Task<IActionResult> Restore(int ? id)
		{
            if (id is null) return BadRequest();
            var category = await _categoryService.GetByIdAsync((int)id);
            if (category is null) return NotFound();

            category.IsDeleted = false;

			await _context.SaveChangesAsync();

			return Ok(category);
        }
	}
}

