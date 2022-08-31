using Microsoft.EntityFrameworkCore;
using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;


namespace MovieApp.Infrastructure.Persistence.Repositories
{
    public sealed class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MovieRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return dbContext.Movies.ToListAsync(cancellationToken);
        }

        public async Task<Movie> GetByIdAsync(int movieId, CancellationToken cancellationToken = default)
        {
            return await dbContext.Movies.FirstOrDefaultAsync(movie=>movie.Id == movieId, cancellationToken);
        }

        public Task Insert(Movie movie)
        {
            dbContext.Movies.Add(movie);
            
            //dbContext.SaveChanges(); //Hier ist ein UnitOfWork Pattern per Default dabei
            return Task.CompletedTask;
        }
    }
}
