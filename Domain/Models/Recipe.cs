using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Recipe
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public List<Ingredient>? Ingredients { get; set; }
		public string? PrepMethod { get; set; }
		public int Difficulty { get; set; }
		public int Rating { get; set; }
		public string? ImagePath { get; set; }
	}
}
