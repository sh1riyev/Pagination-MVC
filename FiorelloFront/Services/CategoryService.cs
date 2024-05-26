using System;
using System.Linq;
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services.Interface;
using FiorelloFront.ViewModels.Categories;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Services
{
	public class CategoryService :ICategoryService
	{
        private readonly AppDbContext _context;
		public CategoryService(AppDbContext context)
		{
            _context = context;
		}

        public async Task CreateAsync(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category category)
        {
             _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return  await _context.Categories.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task<IEnumerable<Category>> GetAllASync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<CategoryProductVM>> GetAllWithProductCountAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.Include(m => m.Products)
                                                                                .ToListAsync();
            return categories.Select(m => new CategoryProductVM {
                Id=m.Id,
                CategoryName = m.Name,
                CreateDate = m.CreateDate.ToString("MM-dd-yyyy"),
                ProductCount=m.Products.Count }
            );
        }

        public  async Task<Category> GetByIdAsync(int id)
        {
              return await _context.Categories.IgnoreQueryFilters().FirstOrDefaultAsync(m=>m.Id==id);
            
        }

        public async Task<Category> Detail(int? id)
        {
            Category categories = await _context.Categories.Include(m => m.Products).ThenInclude(m => m.ProductImages).FirstOrDefaultAsync(m => m.Id == id);
            return categories;
        }

        public async Task<IEnumerable<CategoryArchiveVM>> GetAllArchive()
        {
            IEnumerable<Category> categories = await _context.Categories.IgnoreQueryFilters().Where(m => m.IsDeleted).OrderByDescending(m => m.Id).ToListAsync();

            return categories.Select(m => new CategoryArchiveVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                CreatedDate = m.CreateDate.ToString("MM,dd,yyyy")
            });
        }

        public async Task<IEnumerable<Category>> GetPaginateData(int take, int page)
        {
            return await _context.Categories.Include(m => m.Products).Skip((page - 1) * take).Take(take).ToListAsync();
        }

        public IEnumerable<CategoryProductVM> GetMapData(IEnumerable<Category> categories)
        {
            return categories.Select(m => new CategoryProductVM
            {
                Id = m.Id,
                CategoryName = m.Name,
                CreateDate = m.CreateDate.ToString("mm,dd,yyyy"),
                ProductCount = m.Products.Count()
            });
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Categories.CountAsync();
        }
    }
}

