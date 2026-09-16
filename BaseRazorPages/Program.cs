using Repositories;
using Services;

namespace BaseRazorPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Razor Pages
            builder.Services.AddRazorPages();

            // Injecao de Dependencia
            builder.Services.AddSingleton<UserRepository>();   // Num projeto real, user AddScoped
            builder.Services.AddSingleton<UserService>();      // Num projeto real, usar UserScoped


            builder.Services.AddSingleton<IngredientRepository>();
            builder.Services.AddSingleton<IngredientsServices>();


            var app = builder.Build();
            app.MapRazorPages();


            app.Run();
        }
    }
}
