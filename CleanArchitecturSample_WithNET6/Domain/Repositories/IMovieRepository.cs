using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Movie> GetByIdAsnyc(int movieId, CancellationToken cancellationToken = default);
        Task Insert(Movie movie);
    }
}
