using System;
using System.ComponentModel.DataAnnotations;

namespace FiorelloFront.ViewModels.Blog
{
	public class BlogEditVM
	{
        public int Id{ get; set; }
        [Required(ErrorMessage = "Input cannot be empty..")]
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile NewImage { get; set; }
        public string Image { get; set; }
    }
}

