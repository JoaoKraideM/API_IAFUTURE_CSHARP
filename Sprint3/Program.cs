using System.Reflection;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Models;
using Repository;
using Repository.Interface;

namespace API.IAFUTURE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //Banco de Dados
            builder.Services.AddDbContext<APIDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("APIDbDatabase"),
                        b => b.MigrationsAssembly("API.IAFUTURE"));
            });

            //Documentação Swagger
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration.GetSection("Swagger:Title").Value,
                    Description = builder.Configuration.GetSection("Swagger:Description").Value,
                    Contact = new OpenApiContact()
                    {
                        Email = builder.Configuration.GetSection("Swagger:Email").Value,
                        Name = builder.Configuration.GetSection("Swagger:Name").Value
                    }

                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                
                swagger.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddScoped<IRepository<Conta>, Repository<Conta>>();
            builder.Services.AddScoped<IRepository<Cliente>, Repository<Cliente>>();
            builder.Services.AddScoped<IRepository<FeedbackCliente>, Repository<FeedbackCliente>>();
            builder.Services.AddScoped<IRepository<InteracaoCliente>, Repository<InteracaoCliente>>();
            builder.Services.AddScoped<IRepository<ResultadoIA>, Repository<ResultadoIA>>();


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
