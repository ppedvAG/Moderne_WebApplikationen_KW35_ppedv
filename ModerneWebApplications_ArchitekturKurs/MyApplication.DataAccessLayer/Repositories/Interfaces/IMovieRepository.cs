using GenericRepositoryPattern;
using MyApplication.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.DataAccessLayer.Repositories.Interfaces
{
    public interface IMovieRepository : IRepositoryBaseAsync<Movie, int>
    {
        // Weitere Methoden hinzufügen 

         Task<IList<Movie>> GetAllOscarMovies(int year);

    }
}
