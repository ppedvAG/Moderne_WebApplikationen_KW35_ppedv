using Mapster;
using MovieApp.Core.Application.Abstractions.Messaging;
using MovieApp.Core.Application.Contracts.Movies;
using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Application.Movies.Queries.GetMovies
{
    internal sealed class GetMoviesQueryHandler : IQueryHandler<GetMoviesQuery, IList<MovieResponse>>
    {
        private readonly IMovieRepository movieRepository;

        public GetMoviesQueryHandler(IMovieRepository movieRepository) //movieRepository kommt später aus dem IOC Container 
        {
            this.movieRepository = movieRepository;
        }

        public async Task<IList<MovieResponse>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            IList<Movie> movies = await movieRepository.GetAllAsync(cancellationToken);

            //List<Movies> -> IList<MovieResponse>
            return movies.Adapt<IList<MovieResponse>>();
        }
    }
}
