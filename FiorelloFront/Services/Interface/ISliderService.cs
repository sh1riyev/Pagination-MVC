using System;
using FiorelloFront.Models;

namespace FiorelloFront.Services.Interface
{
	public interface ISliderService
	{
		Task<IEnumerable<Slider>> GetAllAsync();
		Task<SliderInfo> GetInfoASync();
	}
}

