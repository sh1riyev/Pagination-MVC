using System;
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services.Interface;
using FiorelloFront.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Services
{
	public class ProductService :IProductService
	{
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(m => m.ProductImages).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWithAsync()
        {
            return await _context.Products.Include(m => m.Category).Include(m => m.ProductImages).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public IEnumerable<ProductVM> GetMapData(IEnumerable<Product> products)
        {
            return products.Select(m => new ProductVM
            {
                Id = m.Id,
                Name = m.Name,
                CategoryName = m.Category.Name,
                Price = m.Price,
                Description = m.Description,
                MainImage = m.ProductImages?.FirstOrDefault(m => m.IsMain)?.Name
            });
        }

        public async Task<IEnumerable<Product>> GetPaginateData(int take,int page)
        {
            return await _context.Products.Include(m => m.Category).Include(m => m.ProductImages).Skip((page-1)*take).Take(take).ToListAsync();
        }
    }
}

