using System;
using FiorelloFront.Models;
using FiorelloFront.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloFront.ViewComponents
{
	public class FooterViewComponent :ViewComponent
	{
		private readonly ISettingService _settingService;
		private readonly ISocialService _socialService;
		public FooterViewComponent(ISettingService settingService,ISocialService socialService)
		{
			_settingService = settingService;
			_socialService = socialService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var data = new FooterVMVC
			{
				Socials = await _socialService.GetAllSocial(),
				Settings = await _settingService.GetAllAsync()
			};
			return View(data);
		}
	}

	public class FooterVMVC
	{
		public IEnumerable<Social> Socials { get; set; }
		public Dictionary<string,string> Settings { get; set; }
	}
}

