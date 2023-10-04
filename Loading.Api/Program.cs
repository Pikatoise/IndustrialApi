using Loading.DAL.Interfaces;
using Loading.DAL.Repositories;
using Loading.DAL;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Loading.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            builder.Services.AddControllers()
                            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseNpgsql(builder.Configuration["ConnectionStrings:PgSql"]); // PostgreSql
                options.UseSqlite("Data Source=loading.db"); // SQLite
            });

            var app = builder.Build();

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowAnyOrigin();
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}