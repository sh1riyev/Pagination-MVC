using System;
using FiorelloFront.Helpers;
using FiorelloFront.Services.Interface;
using FiorelloFront.ViewModels;
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
		public async Task<IActionResult >Index(int page=1)
		{
			var products = await _productService.GetPaginateData(page, 4);

			var mappedDatas = _productService.GetMapData(products);

            int totalPage = await GetPageCount(4);

			Paginate<ProductVM> paginateDatas = new(mappedDatas, totalPage, page);

			return View(paginateDatas);
		}


		private async Task<int> GetPageCount(int take)
		{
			int productCount = await _productService.GetCountAsync();

			return (int)Math.Ceiling((decimal)productCount / take);
		}
	}
}

