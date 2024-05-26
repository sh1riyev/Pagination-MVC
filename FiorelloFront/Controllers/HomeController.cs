using Microsoft.AspNetCore.Mvc;
using FiorelloFront.Services.Interface;
using FiorelloFront.ViewModels;
using FiorelloFront.ViewModels.Baskets;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FiorelloFront.Controllers;

public class HomeController : Controller
{
    private readonly IBlogService _blogService;
    private readonly IExpertService _expertService;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;
    private readonly IHttpContextAccessor _accessor;
    public HomeController(IBlogService blogService,

        IExpertService expertService,
        ICategoryService categoryService,
        IProductService productService,
        IHttpContextAccessor accessor)
    {
        _blogService = blogService;
        _expertService = expertService;
        _categoryService = categoryService;
        _productService = productService;
        _accessor = accessor;
    }
    public async Task<IActionResult> Index()
    {

        HomeVM model = new()
        {
            Blogs = await _blogService.GetAllAsync(3),
            Experts = await _expertService.GetAllAsync(),
            Products=await _productService.GetAllAsync(),
            Categories=await _categoryService.GetAllASync()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductToBasket(int? id)
    {
        if (id is null) return BadRequest();

        var product = await _productService.GetByIdAsync((int)id);

        if (product is null) return NotFound();

        List<BasketVM> baskets;

        if (_accessor.HttpContext.Request.Cookies["basket"] is not null)
        {
            baskets = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
        }
        else
        {
            baskets = new List<BasketVM>();
        }

        var existBasket = baskets.FirstOrDefault(m => m.Id == id);

        if(existBasket is not null)
        {
            existBasket.Count++;
        }
        else
        {
            baskets.Add(new BasketVM
            {
                Id = (int)id,
                Price = product.Price,
                Count = 1
            });
        }



        _accessor.HttpContext.Response.Cookies.Append("basket",JsonConvert.SerializeObject(baskets));

        int count = baskets.Sum(m => m.Count);
        decimal totalPrice = baskets.Sum(m => m.Count * m.Price);

        return Ok(new {count,totalPrice});
    }
}

