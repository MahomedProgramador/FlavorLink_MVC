
namespace Domain.Models
{
	public class Recipe
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Ingredient> Ingredients { get; set; }
		public string? PrepMethod { get; set; }
		public int? Difficulty { get; set; }
		public int? Rating { get; set; }
		public string ImagePath { get; set; }

		public override bool Equals(object obj)
		{
			return obj is Recipe recipe &&
				   Id == recipe.Id &&
				   Name == recipe.Name &&
				   EqualityComparer<List<Ingredient>>.Default.Equals(Ingredients, recipe.Ingredients) &&
				   PrepMethod == recipe.PrepMethod &&
				   Difficulty == recipe.Difficulty &&
				   Rating == recipe.Rating &&
				   ImagePath == recipe.ImagePath;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Name, Ingredients, PrepMethod, Difficulty, Rating, ImagePath);
		}
	}
}
