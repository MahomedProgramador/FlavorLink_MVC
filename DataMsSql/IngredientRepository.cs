using Domain.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMsSql
{
	public class IngredientRepository : IIngredientRepository
	{

		private string _tableName = "Ingredients";
		private readonly string _cs = "Server=localhost\\SQLEXPRESS;Database=FlavorLink;Trusted_Connection=True;TrustServerCertificate=True;";

		public int Add(Ingredient ingredient)
		{
			string query = $"INSERT INTO {_tableName}(name, measurement) " +
						   $"VALUES ('{ingredient.Name}', '{ingredient.Measurement}') " +
						   $"SELECT SCOPE_IDENTITY() as 'SCOPE_IDENTITY'";

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			return Convert.ToInt32(cmd.ExecuteScalar());				
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<Ingredient> GetAll()
		{
			throw new NotImplementedException();
		}

		public Ingredient GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Ingredient ingredient)
		{
			throw new NotImplementedException();
		}
	}
}
