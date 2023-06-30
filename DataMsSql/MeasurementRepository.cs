using Domain.Models;
using Services.Contracts;
using Services.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMsSql
{
	public class MeasurementRepository : IMeasurementRepository
	{		
		private readonly string _cs = "Server=localhost\\SQLEXPRESS;Database=FlavorLink;Trusted_Connection=True;TrustServerCertificate=True;";

		public void Add()
		{
			throw new NotImplementedException();
		}

		//      public int Add(Measurement measurement)
		//{
		//	string query = $"INSERT INTO {TableName.Measurement} (unit) " +
		//				   $"VALUES ('{measurement.Unit}') " +
		//				   $"SELECT SCOPE_IDENTITY() as 'SCOPE_IDENTITY'";

		//	using SqlConnection conn = new SqlConnection(_cs);

		//	conn.Open();

		//	using SqlCommand cmd = conn.CreateCommand();
		//	cmd.CommandText = query;


		//	return ingredient.Id;
		//}

		public IEnumerable<Measurement> GetAll()
		{
			var list = new List<Measurement>();

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			string query = $"SELECT * FROM {TableName.Measurement}";
			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				Measurement entity = new Measurement();
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Unit = Convert.ToString(dr["unit"]);

				list.Add(entity);
			}
			return list;
		}

		public Measurement GetById(int id)
		{

			id = 21;
			Measurement entity = new Measurement();

			string query = $"SELECT * from {TableName.Measurement} WHERE id = {id}";

			using SqlConnection conn = new SqlConnection(_cs);

			conn.Open();

			using SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = query;

			SqlDataReader dr = cmd.ExecuteReader();

			while (dr.Read())
			{
				entity.Id = Convert.ToInt32(dr["id"]);
				entity.Unit = Convert.ToString(dr["unit"]);
				
			}

			throw new NotImplementedException();
		}

		

		public void Update()
		{
			throw new NotImplementedException();
		}
	}
}
