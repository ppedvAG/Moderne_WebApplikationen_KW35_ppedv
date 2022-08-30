using CQRS_WITH_MEDIATR.Data.Entities;
using MediatR;

namespace CQRS_WITH_MEDIATR.Queries
{
    public record GetMovieByIdQuery(int Id) : IRequest<Movie>;
}
