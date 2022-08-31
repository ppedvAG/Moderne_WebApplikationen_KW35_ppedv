using Application.Abstractions.Messaging;
using Application.Contracts.Movies;
using Domain.Entities;
using Domain.Repositories;
using Mapster;


namespace Application.Movies.Queries.GetMovies
{
    internal sealed class GetMoviesQueryHandler : IQueryHandler<GetMoviesQuery, IList<MovieResponse>>
    {
        private readonly IMovieRepository movieRepository;



        //Kommen später aus dem IOC Container

        public GetMoviesQueryHandler(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<IList<MovieResponse>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            IList<Movie> movies = await movieRepository.GetAllAsync(cancellationToken);

            //Mapster 
            return movies.Adapt<IList<MovieResponse>>();
        }



    }
}
