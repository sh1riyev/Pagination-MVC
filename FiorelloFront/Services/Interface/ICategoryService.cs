using System;
using FiorelloFront.Models;
using FiorelloFront.ViewModels.Categories;

namespace FiorelloFront.Services.Interface
{
	public interface ICategoryService
	{
		public Task<IEnumerable<Category>> GetAllASync();
		public Task<IEnumerable<CategoryProductVM>> GetAllWithProductCountAsync();
		public Task<Category> GetByIdAsync(int id);
		public Task<bool> ExistAsync(string name);
		public Task CreateAsync(Category category);
		public Task DeleteAsync(Category category);
		Task<Category> Detail(int? id);
		Task<IEnumerable<CategoryArchiveVM>> GetAllArchive();
    }
}

