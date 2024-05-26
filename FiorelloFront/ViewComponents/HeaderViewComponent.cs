using System;
using System.ComponentModel;
using FiorelloFront.Services.Interface;
using FiorelloFront.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FiorelloFront.ViewComponents
{
	public class HeaderViewComponent : ViewComponent
	{
		private readonly ISettingService _settingService;
		private readonly IHttpContextAccessor _accessor;
		public HeaderViewComponent(ISettingService settingService, IHttpContextAccessor accessor)
		{
			_settingService = settingService;
			_accessor = accessor;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<BasketVM> baskets;

			if (_accessor.HttpContext.Request.Cookies["basket"] is not null)
			{
                baskets = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }
			else
			{
				baskets = new List<BasketVM>();
			}

			Dictionary<string, string> settings = await _settingService.GetAllAsync();

			HeaderVM response = new()
			{
				Settings = settings,
				BasketCount = baskets.Sum(m => m.Count),
				BasketTotalPrice = baskets.Sum(m => m.Count * m.Price)
			};

            return await Task.FromResult(View(response));
		}
	}

	public class HeaderVM
	{
		public int BasketCount { get; set; }
		public decimal BasketTotalPrice { get; set; }
		public Dictionary<string, string> Settings { get; set; }
	}

}