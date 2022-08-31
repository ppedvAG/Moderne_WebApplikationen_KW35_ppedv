using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Application.Movies.Commands.UpdateMovie
{
    //DTO Object für die Request
    public sealed record UpdateMovieRequest(int Id, string Title, string Description, decimal Price, int GenreType);
}
