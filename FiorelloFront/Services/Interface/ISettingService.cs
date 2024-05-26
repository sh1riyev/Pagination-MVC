using System;
namespace FiorelloFront.Services.Interface
{
	public interface ISettingService
	{
		Task<Dictionary<string, string>> GetAllAsync();
	}
}

