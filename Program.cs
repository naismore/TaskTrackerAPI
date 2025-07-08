
using Microsoft.EntityFrameworkCore;
using TaskTracker.Backend.Repositories;

namespace TaskTracker.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            string connection = builder.Configuration.GetConnectionString("Database")!;

            System.Console.WriteLine(connection);

            builder.Services.AddDbContext<MyDbContext>(options => options.UseNpgsql(connection));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

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
