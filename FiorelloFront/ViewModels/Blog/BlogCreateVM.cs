using System;
using System.ComponentModel.DataAnnotations;
using FiorelloFront.Models;

namespace FiorelloFront.ViewModels.Blog
{
	public class BlogCreateVM 
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Input cannot be empty..")]
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}

