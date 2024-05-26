using System;
using FiorelloFront.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloFront.Controllers
{
	[Area("Admin")]
	public class ProductController :Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult >Index()
		{
			var products = await _productService.GetAllWithAsync();

			var mappedDatas = _productService.GetMapData(products);

			return View(mappedDatas);
		}
	}
}

