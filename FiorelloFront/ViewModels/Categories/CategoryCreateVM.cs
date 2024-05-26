using System;
using System.ComponentModel.DataAnnotations;

namespace FiorelloFront.ViewModels.Categories
{
	public class CategoryCreateVM
	{
		[Required (ErrorMessage ="Input cannot be empty..")]
		public string Name { get; set; }
	}
}

