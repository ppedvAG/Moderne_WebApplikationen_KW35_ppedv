using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Application.Movies.Commands.CreateMovie
{
    public sealed record CreateMovieRequest(string Title, string Description, decimal Price, int Genre);
}
