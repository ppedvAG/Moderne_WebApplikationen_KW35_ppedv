using CQRS_WITH_MEDIATR.Data.Entities;
using MediatR;

namespace CQRS_WITH_MEDIATR.Commands
{
    public record AddMovieCommand (Movie Movie) : IRequest<Movie>;
}
