using System;
using FiorelloFront.Models;
using FiorelloFront.ViewModels;

namespace FiorelloFront.Services.Interface
{
	public interface IBlogService
	{
        public Task<IEnumerable<BlogVM>> GetAllAsync(int? take = null);
        Task CreateAsync(Blog blog);
        Task DeleteAsync(Blog blog);
        Task<bool> ExistAsync(string name);
        Task<Blog> GetByid(int? id);
    }
}

