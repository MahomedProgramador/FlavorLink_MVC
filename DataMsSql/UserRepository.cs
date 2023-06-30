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
    public class UserRepository : IUserRepository
    {
        private string _tableName = "users";
        private readonly string _cs = "Server=localhost\\SQLEXPRESS;Database=FlavorLink;Trusted_Connection=True;TrustServerCertificate=True;";
        public User Login(string username, string password)
        {
            string query = $"SELECT * " +
                $"FROM {TableName.Users} " +
                $"WHERE user_name = '{username}' AND password = '{password}';";

            using SqlConnection conn = new SqlConnection(_cs);

            conn.Open();

            using SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                User user = new User();
                user.Id = Convert.ToInt32(dr["id"]);
                user.Username = Convert.ToString(dr["user_name"]);
                user.Password = Convert.ToString(dr["password"]);
                user.isAdmin = Convert.ToBoolean(dr["is_admin"]);

                return user;
            }
            throw new KeyNotFoundException($"User Not Found");
        }

        public User Register(string username, string password)
        {
            string query = $"INSERT " +
                           $"INTO {TableName.Users} " +
                           $"VALUES('{username}', '{password}', 0);";

            using SqlConnection conn = new SqlConnection(_cs);

            conn.Open();

            using SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;

            int rows = cmd.ExecuteNonQuery();

            User user = new User();
            if (rows > 0)
            {
				user.Username = username;
				user.Password = password;
				user.isAdmin = false;

				return user;
			}

			return null;
		}

        public bool UserExists(string username)
        {
            
            string query = $"SELECT COUNT(*) FROM {TableName.Users} WHERE user_name = '{username}';";            

            using SqlConnection conn = new SqlConnection(_cs);

            conn.Open();

            using SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;           

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            return count > 0;          
        }
    }
}
