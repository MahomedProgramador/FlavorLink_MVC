using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class IngredientV2
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Measurement Measurement { get; set; }		
		
	}
}
