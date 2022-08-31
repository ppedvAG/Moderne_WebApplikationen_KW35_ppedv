using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Commands.UpdateMovie
{
    internal sealed class UpdateMovieCommandHandler : ICommandHandler<UpdateMovieCommand, Unit>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUnitOfWork _unitOfWork;
        //Kommen später aus dem IOC Container
        public UpdateMovieCommandHandler(IMovieRepository userRepository, IUnitOfWork unitOfWork)
        {
            _movieRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            //Orginaldatensatz aus DB
            Movie movie = await _movieRepository.GetByIdAsnyc(request.MovieId, cancellationToken);

            if (movie is null)
            {
                throw new MovieNotFoundException(request.MovieId);
            }
            //Datansatz ist immer noch Attached -> EF Core Kompatibel.

            //!!!!!!!!!!!!!!!!!! In ADO.NET müsste man hier eine seperate Update-Methode aufrufen 
            movie.Id = request.MovieId;
            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Price = request.Price;
            movie.Genre = request.Genre;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
