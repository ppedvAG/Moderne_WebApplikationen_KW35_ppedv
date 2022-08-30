using CQRS_WITH_MEDIATR.Data.Entities;
using MediatR;

namespace CQRS_WITH_MEDIATR.Queries
{
    //records sind Klassen mit Wertevergleiche und weiteren Funktionen (ToString(), GetHashCode(), Equals - Impl.) 

    //Syntax: IEnumerarble<Movie> ist der Rückgabewert unserer Anfrage
    public record GetMovieQuery() : IRequest<IEnumerable<Movie>>;
}
