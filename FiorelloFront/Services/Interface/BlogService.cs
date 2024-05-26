using System;
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFront.Services.Interface
{
	public class BlogService : IBlogService
	{
        private readonly AppDbContext _context;
		public BlogService(AppDbContext context)
		{
            _context = context;
		}

        public async Task CreateAsync(Blog blog)
        {
            await _context.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Categories.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task DeleteAsync(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogVM>> GetAllAsync(int? take=null)
        {
            IEnumerable<Blog> blogs ;
            if(take is null)
            {
                blogs = await _context.Blogs.ToListAsync();

            }
            else
            {
                blogs = await _context.Blogs.Take((int)take).ToListAsync();
            }
            return blogs.Select(m => new BlogVM { Id=m.Id,Title = m.Title, Description = m.Description, Image = m.Image, CreateDate = m.CreateDate.ToString() });
        }

        public async Task<Blog> GetByid(int? id)
        {
            return await _context.Blogs.FindAsync(id);
        }
    }
}

