using GenericRepositoryPattern.EfCore;
using Microsoft.EntityFrameworkCore;
using MyApplication.DataAccessLayer.DataContext;
using MyApplication.DataAccessLayer.Entities;
using MyApplication.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.DataAccessLayer.Repositories
{
    public class MovieRepository : EfCoreRepositoryBase<Movie, int>, IMovieRepository
    {
        public MovieRepository(MyApplicationDbContext dbContext) : base(dbContext)
        {
        }

        #region Zwei Varianten im Zugriff -> Variante 
        public async Task<IList<Movie>> GetAllOscarMovies(int year)
        {
            return await GetByExpressionAsync(m => m.Year == year && m.HaveOscar == true);
        }

        public async Task<IList<Movie>> GetAllOscarMoviesB(int year)
        {
            return await ((MyApplicationDbContext)dbContext).Movies.Where(m => m.Year == year && m.HaveOscar == true).ToListAsync();

        }
        #endregion
    }
}
