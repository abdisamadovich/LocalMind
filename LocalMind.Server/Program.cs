using LocalMind.Server.DataContext;
using LocalMind.Server.Repository.Users;
using LocalMind.Server.Service.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

namespace LocalMind.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LocalMind API", Version = "v1" });
            });
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddDbContext<ApplicationDbContext>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.MapStaticAssets();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LocalMind API V1");
                    c.RoutePrefix = "swagger";
                });
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}