using CrudEF.Configuration;
using CrudEF.DB;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrudEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(MapperConfig));

            string connection = builder.Configuration.GetConnectionString("DbConnectionString");

            builder.Services.AddDbContext<ArtisianContext>(options => options.UseSqlServer(connection));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

                   

            app.Run();
        }
    }
}