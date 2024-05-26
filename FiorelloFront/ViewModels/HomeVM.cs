using System;
using FiorelloFront.Models;

namespace FiorelloFront.ViewModels
{
	public class HomeVM
	{
		public IEnumerable<BlogVM> Blogs { get; set; }
		public IEnumerable<Experts> Experts { get; set; }
		public IEnumerable<Product>  Products{ get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}

