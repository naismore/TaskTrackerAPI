
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            string connection = builder.Configuration.GetConnectionString("Database")!;

            System.Console.WriteLine(connection);

            builder.Services.AddDbContext<MyDbContext>(options => options.UseNpgsql(connection));
            builder.Services.AddScoped<UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
