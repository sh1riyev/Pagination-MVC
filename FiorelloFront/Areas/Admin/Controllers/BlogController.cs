using System.IO;
using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.Services;
using FiorelloFront.Services.Interface;
using FiorelloFront.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FiorelloFront.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _env;
        public BlogController(IBlogService blogService, IWebHostEnvironment env,AppDbContext context)
        {
            _blogService = blogService;
            _env = env;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _blogService.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(BlogCreateVM blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var blogs = await _blogService.GetAllAsync();

            if (blogs.Any(m => m.Title == blog.Title))
            {
                ModelState.AddModelError("Title", "Title is used");
                return View();
            }

            if (!blog.Image.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Image", "Input can be only image");
                return View();
            }

            if (!(blog.Image.Length / 1024 < 200))
            {
                ModelState.AddModelError("Image", "Image size too large");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "-" + blog.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using(FileStream stream = new FileStream(path, FileMode.Create))
            {
                await blog.Image.CopyToAsync(stream);
            }

            await _blogService.CreateAsync(new Blog { Title = blog.Title,Description=blog.Description,Image=fileName });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var blog = await _blogService.GetByid((int)id);
            if (blog is null) return NotFound();

            string path = Path.Combine(_env.WebRootPath, "img", blog.Image);

           if( System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            await _blogService.DeleteAsync(blog);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var blog = await _blogService.GetByid((int)id);

            if (blog is null) return NotFound();

            return View(new BlogEditVM { Id = blog.Id, Title = blog.Title, Description = blog.Title,Image=blog.Image });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,BlogEditVM request)
        {
            if (id is null) return BadRequest();

            var blog = await _blogService.GetByid((int)id);

            if (blog is null) return NotFound();

            if (request.NewImage is null) return RedirectToAction(nameof(Index));

            string oldPath = Path.Combine(_env.WebRootPath, "img", blog.Image);

            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }

            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

            string newPath = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await request.NewImage.CopyToAsync(stream);
            }

            bool isExist = await _blogService.ExistAsync(request.Title);

            if (isExist == true) return RedirectToAction(nameof(Index));

            new BlogEditVM { Id = blog.Id, Title = blog.Title, Description = blog.Title,Image=fileName };

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
             
        }
    }
}

