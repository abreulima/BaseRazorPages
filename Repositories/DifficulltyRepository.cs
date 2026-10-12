using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{

    public class DifficulltyRepository
    {

        private readonly string connString;

        public DifficulltyRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<DifficulltyRepository>()
            .Build();

            //connString = config["AmazonSQL"];
            connString = "Server=63.35.214.23,1433;Database=p1;User Id=sa;Password=@Pizza123;TrustServerCertificate=True;"
       }

        public List<Difficulty> GetDifficulties()
        {
            List<Difficulty> difficulties = new List<Difficulty>();

            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("SELECT id, name FROM Difficulty", sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Difficulty difficulty = new Difficulty
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                difficulties.Add(difficulty);
            }

            sqlConnection.Close();
            return difficulties;
        }

        public void AddDifficult(Difficulty difficulty)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("Insert into Difficulty values (@name)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", difficulty.Name);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


    }
}
