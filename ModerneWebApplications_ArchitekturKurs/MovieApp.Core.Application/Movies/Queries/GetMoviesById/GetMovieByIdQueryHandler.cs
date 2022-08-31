using Mapster;
using MovieApp.Core.Application.Abstractions.Messaging;
using MovieApp.Core.Application.Contracts.Movies;
using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Exceptions;
using MovieApp.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Application.Movies.Queries.GetMoviesById
{
    internal sealed class GetMovieByIdQueryHandler : IQueryHandler<GetMovieByIdQuery, MovieResponse>
    {
        private readonly IMovieRepository movieRepository;

        public GetMovieByIdQueryHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            Movie movie = await movieRepository.GetByIdAsync(request.MovieId, cancellationToken);

            if (movie is null)
                throw new MovieNotFoundException(request.MovieId);

            return movie.Adapt<MovieResponse>();
        }
    }
}
