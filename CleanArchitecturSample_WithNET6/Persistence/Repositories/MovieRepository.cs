using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Repositories
{
    public sealed class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public MovieRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
         => _dbContext.Movies.ToListAsync(cancellationToken);

        public Task<Movie> GetByIdAsnyc(int movieId, CancellationToken cancellationToken = default)
            => _dbContext.Movies.FirstOrDefaultAsync(user => user.Id == movieId, cancellationToken);
        

        public Task Insert(Movie movie)
        {
            _dbContext.Movies.Add(movie);

            return Task.CompletedTask;
        }
    }
}
