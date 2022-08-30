using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyApplication.DataAccessLayer.DataContext;
using MyApplication.DataAccessLayer.Entities;
using MyApplication.DataAccessLayer.Repositories;
using MyApplication.DataAccessLayer.Repositories.Interfaces;

namespace MyApplication.App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region Auslesen des Connection-Strings
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("MovieDbConnectionString");
            #endregion

            #region Instanziieren von MyApplicationDbContext
            MyApplicationDbContext context = new MyApplicationDbContext(connectionString);
            #endregion




            //Db
            IMovieRepository movieRepository = new MovieRepository(context);

            //Speichere Datensatz
            await movieRepository.AddAsync(new Movie() { Title = "Scary Movie", Description = "Lachen ist Gesund", Price = 9.99m, HaveOscar = true, Year = 2022 });
            await movieRepository.AddAsync(new Movie() { Title = "Scary Movie 2", Description = "Lachen ist gesünder", Price = 9.99m, HaveOscar = true, Year = 2022 });



            IList<Movie> moviesWithOscars = await movieRepository.GetAllOscarMovies(2022);
        }
    }
}