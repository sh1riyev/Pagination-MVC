using System;
using FiorelloFront.Models;
using FiorelloFront.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloFront.ViewComponents
{
	public class SliderViewComponent : ViewComponent
	{
		private readonly ISliderService _sliderService;
		public SliderViewComponent(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var data = new SliderVMVC
			{
				Sliders = await _sliderService.GetAllAsync(),
				SliderInfo = await _sliderService.GetInfoASync()
			};
			return await Task.FromResult(View(data));
		}
	}

	public class SliderVMVC
	{
		public IEnumerable<Slider> Sliders { get; set; }
		public SliderInfo SliderInfo { get; set; }
	}
}

