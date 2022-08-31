using MediatR;
using MovieApp.Core.Application.Abstractions.Messaging;
using MovieApp.Core.Domain.Entities;
using MovieApp.Core.Domain.Exceptions;
using MovieApp.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Application.Movies.Commands.UpdateMovie
{
    internal sealed class UpdateMovieCommandHandler : ICommandHandler<UpdateMovieCommand, Unit>
    {
        private readonly IMovieRepository movieRepository;
        private readonly IUnitOfWork unitOfWork;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
        {
            this.movieRepository = movieRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            Movie movie = await movieRepository.GetByIdAsync(request.MovieId, cancellationToken);

            if (movie is null)
                throw new MovieNotFoundException(request.MovieId);

            //Aktualisieren die Werte
            movie.Id = request.MovieId;
            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Price = request.Price;
            movie.Genre = request.Genre;

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
