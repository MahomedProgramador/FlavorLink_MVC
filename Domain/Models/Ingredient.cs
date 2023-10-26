using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Quantity { get; set; }
		public Measurement Measurement { get; set; }
	}

	public class IngredientLine
	{
		public int Id { get; set; }
		public Ingredient ingredient { get; set; }
		public double Quantity { get; set; }
		public Measurement Measurement { get; set; }

	}
}
