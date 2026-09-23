using Microsoft.Data.SqlClient;
using Models;
using Microsoft.Extensions.Configuration;

namespace Repositories
{
    public class UserRepository
    {
        readonly string connString;

        public UserRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<UserRepository>().Build();
            connString = config.GetConnectionString("AmazonSQL");
            Console.WriteLine(connString);
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("SELECT name, password, isAdmin FROM Users", sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                User user = new User();
                user.Name = reader.GetString(0);
                user.Password = reader.GetString(1);
                user.IsAdmin = reader.GetBoolean(2);
                users.Add(user);
            }

            sqlConnection.Close();

            return users;
        }

        public void AddUser(User user)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Users (name, password, isAdmin) VALUES (@name, @password, @isAdmin)", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@name", user.Name);
            sqlCommand.Parameters.AddWithValue("@password", user.Password);
            sqlCommand.Parameters.AddWithValue("@isAdmin", user.IsAdmin);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}
