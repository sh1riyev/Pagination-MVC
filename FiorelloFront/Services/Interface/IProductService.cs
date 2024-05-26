using System;
using FiorelloFront.Models;
using FiorelloFront.ViewModels;

namespace FiorelloFront.Services.Interface
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAllAsync();
		Task<Product> GetByIdAsync(int id);
		Task<IEnumerable<Product>> GetAllWithAsync();
        IEnumerable<ProductVM> GetMapData(IEnumerable<Product> products);
	}
}

