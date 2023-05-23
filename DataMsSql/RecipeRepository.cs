

using Domain.Models;
using Services.Contracts;
using System.Data.SqlClient;
using System.Transactions;

namespace DataMsSql
{
	public class RecipeRepository : IRecipeRepository
	{
		private string _tableName = "FlavorLinkRecipe";

		private readonly string _cs = "Server=localhost\\SQLEXPRESS;Database=FlavorLink;Trusted_Connection=True;TrustServerCertificate=True;";
		public Recipe Add(Recipe entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"DELETE FROM {_tableName} WHERE id = {id}";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			cmd.ExecuteNonQuery();
		}

		public void Delete(Recipe entity)
		{
			Delete(entity.Id);
		}

		public List<Recipe> GetAll()
		{
			var list = new List<Recipe>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT * FROM {_tableName}";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Recipe entity = new Recipe();
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Name = Convert.ToString(dr["name"]);
				entity.Ingredients= new List<Ingredient>();
				Ingredient i = new Ingredient();
				i.Id = Convert.ToInt32(dr["ingredients"]);
				entity.Ingredients.Add(i);
				entity.PrepMethod = Convert.ToString(dr["prep_method"]);
				entity.Difficulty = Convert.ToInt32(dr["difficulty"]);
				entity.Rating = Convert.ToInt32(dr["rating"]);
				entity.ImagePath = Convert.ToString(dr["image_path"]);
				
				list.Add(entity);
			}

			return list;
		}

		public Recipe GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Recipe Update(Recipe entity)
		{
			throw new NotImplementedException();
		}
	}
}
