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

namespace MovieApp.Core.Application.Movies.Commands.CreateMovie
{
    public sealed class CreateMovieCommandHandler : ICommandHandler<CreateMovieCommand, MovieResponse>
    {
        private readonly IMovieRepository movieRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateMovieCommandHandler(IMovieRepository movieRepository,IUnitOfWork unitOfWork)
        {
            this.movieRepository = movieRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            //MediatR CreateCommand -> Movie EF-Entity
            Movie movie = new Movie();
            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Price = request.Price;
            movie.Genre = request.Genre;

            await movieRepository.Insert(movie);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return movie.Adapt<MovieResponse>();
        }
    }
}
