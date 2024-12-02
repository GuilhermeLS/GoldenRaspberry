using Microsoft.EntityFrameworkCore;
using GoldenRaspberry.Application.Services;
using GoldenRaspberry.Domain.Entities;
using GoldenRaspberry.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using GoldenRaspberry.Infrastructure.Context;
using GoldenRaspberry.Application.Interfaces;
using GoldenRaspberry.Infrastructure.Interfaces;




namespace GoldenRaspberryAwards
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieAppService, MovieAppService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Golden Raspberry Awards API",
                    Version = "v1",
                    Description = "API para consultar dados dos indicados e vencedores do Golden Raspberry Awards",
                    Contact = new OpenApiContact
                    {
                        Name = "Guilherme Lima Silva",
                        Email = "guilherme.spw@hotmail.com",
                        Url = new Uri("https://github.com/GuilhermeLS")
                    }
                });
            });

            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("GoldenRaspberryDb"));
            
        }

        public void Configure(IApplicationBuilder app, AppDbContext dbContext)
        {
            // Inicializa o banco de dados com dados do CSV
            SeedDatabase(dbContext);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Golden Raspberry Awards API v1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SeedDatabase(AppDbContext context)
        {
            var csvFilePath = Configuration["CsvFile:Path"];
            var movies = LoadMoviesFromCsv(csvFilePath);
            if (movies != null && movies.Any())
            {
                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }

        private static IEnumerable<Movie> LoadMoviesFromCsv(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            var movies = new List<Movie>();
            var id = 0;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) 
            {
                var columns = line.Split(';');

                if (columns.Length < 5)
                    continue;
                
                id++;
                movies.Add(new Movie
                {
                    Id = id,
                    Year = int.Parse(columns[0].Trim()),
                    Title = columns[1].Trim(),
                    Studios = columns[2].Trim(),
                    Producers = columns[3].Trim(),
                    IsWinner = columns[4].Trim().ToLower() == "yes"
                });
            }

            return movies;
        }
    }
}
