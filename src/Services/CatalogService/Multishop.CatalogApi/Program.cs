using Microsoft.Extensions.Options;
using Multishop.CatalogApi.Services.CategoryServices;
using Multishop.CatalogApi.Services.ProductDetailDetailServices;
using Multishop.CatalogApi.Services.ProductDetailServices;
using Multishop.CatalogApi.Services.ProductImageImageServices;
using Multishop.CatalogApi.Services.ProductImageServices;
using Multishop.CatalogApi.Services.ProductServices;
using Multishop.CatalogApi.Settings;
using System.Reflection;


namespace Multishop.CatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductDetailService,ProductDetailService>();
            builder.Services.AddScoped<IProductImageService, ProductImageService>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
            builder.Services.AddScoped<IDatabaseSettings>(sp =>
            {
                return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
