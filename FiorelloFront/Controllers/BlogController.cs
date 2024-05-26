using System;
using FiorelloFront.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloFront.Controllers
{
	public class BlogController :Controller
	{
		private readonly IBlogService _blogService;
		public BlogController(IBlogService blogService)
		{
			_blogService = blogService;
		}
		public async Task<IActionResult >Index()
		{
			return View(await _blogService.GetAllAsync());
		}
	}
}

