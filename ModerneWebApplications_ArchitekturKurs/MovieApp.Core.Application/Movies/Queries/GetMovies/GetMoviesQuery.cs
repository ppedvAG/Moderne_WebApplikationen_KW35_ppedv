using MovieApp.Core.Application.Abstractions.Messaging;
using MovieApp.Core.Application.Contracts.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Application.Movies.Queries.GetMovies
{
    public sealed record GetMoviesQuery() : IQuery<IList<MovieResponse>>;
}
