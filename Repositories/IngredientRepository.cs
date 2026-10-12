using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class IngredientRepository
    {

        private readonly string connString;

        public IngredientRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<UserRepository>()
            .Build();

            //connString = config["AmazonSQL"];
            connString = "Server=63.35.214.23,1433;Database=p1;User Id=sa;Password=@Pizza123;TrustServerCertificate=True;";

        }

        public List<Ingredient> GetIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();

            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("SELECT id, name FROM Ingredients", sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Ingredient ingredient = new Ingredient
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                ingredients.Add(ingredient);
            }

            sqlConnection.Close();
            return ingredients;

        }

        public void AddIngredient(Ingredient ingredient)
        {
            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("Insert into Ingredients values (@name)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", ingredient.Name);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
