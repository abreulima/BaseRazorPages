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
            builder.Services.AddScoped<UserRepository>();   // Num projeto real, user AddScoped
            builder.Services.AddScoped<UserService>();      // Num projeto real, usar UserScoped


            builder.Services.AddScoped<IngredientRepository>();
            builder.Services.AddScoped<IngredientsServices>();

            builder.Services.AddScoped<DifficulltyRepository>();
            builder.Services.AddScoped<DifficultyService>();


            /* Adicionado */
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            /* Adicionado */

            var app = builder.Build();

            app.UseSession(); // Adiciona sessoes
            app.UseStaticFiles(); // Permite aceder os ficheiros da pasta wwwroot
            app.MapRazorPages();


            app.Run("http://0.0.0.0:3000");
        }
    }
}
