using Application.Abstractions.Messaging;
using Application.Contracts.Movies;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;

namespace Application.Movies.Queries.GetMoviesById
{
    internal sealed class GetMovieByIdQueryHandler : IQueryHandler<GetMovieByIdQuery, MovieResponse>
    {
        private readonly IMovieRepository _movieRepository;



        //Kommen später aus dem IOC Container
        public GetMovieByIdQueryHandler(IMovieRepository movieRepository) => _movieRepository = movieRepository;

        public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _movieRepository.GetByIdAsnyc(request.MovieId, cancellationToken);

            if (user is null)
            {
                throw new MovieNotFoundException(request.MovieId);
            }

            return user.Adapt<MovieResponse>();
        }
    }
}
