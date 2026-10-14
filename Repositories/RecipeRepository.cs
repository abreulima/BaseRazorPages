using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class RecipeRepository
    {

        readonly string connString;

        public RecipeRepository()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<RecipeRepository>()
            .Build();

            connString = config["AmazonSQL"];
            //connString = "Server=63.35.214.23,1433;Database=p1;User Id=sa;Password=@Pizza123;TrustServerCertificate=True;";

        }

        public Recipe? GetRecipe(int id)
        {

            SqlConnection sqlConnection = new SqlConnection(connString);
            SqlCommand sqlCommand = new SqlCommand("SELECT id, name FROM Recipes WHERE id = @id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);

            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (!reader.HasRows)
            {
                return null;
            }

            reader.Read();

            Recipe recipe = new Recipe();
            recipe.Id = reader.GetInt32(0);
            recipe.Name = reader.GetString(1);
            recipe.Id = reader.GetInt32(0);
            recipe.Name = reader.GetString(1);
            //recipe.Id = reader.GetInt32(0);
            //recipe.Name = reader.GetString(1);

            sqlCommand = new SqlCommand("select Ingredients.id, Ingredients.name from RecipeIngredients " +
                "join Ingredients ON RecipeIngredients.ingredientId = Ingredients.id " +
                "where RecipeIngredients.recipeId = @recipeId;", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@recipeId", id);

            reader.Close();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Ingredient ingredient = new Ingredient();
                ingredient.Id = reader.GetInt32(0);
                ingredient.Name = reader.GetString(1);
                recipe.Ingredients.Add(ingredient);
            }

            sqlConnection.Close();

            return recipe;

        }
    }
}
