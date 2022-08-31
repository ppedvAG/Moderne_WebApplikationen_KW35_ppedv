using CQRS_WITH_MEDIATR.Data.Entities;
using MediatR;

namespace CQRS_WITH_MEDIATR.Commands
{
    //public record AddMovieCommand (PARAMETER) : IRequest<RÜCKGABETYP>;
    public record AddMovieCommand (Movie Movie) : IRequest<Movie>;

    //Unit symbolisiert in MediatR das 'void'
    public record AddMovieWithReturnType (Movie Movie) : IRequest<Unit>;
}
