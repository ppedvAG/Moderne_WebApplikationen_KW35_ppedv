using Domain.Entities;

namespace Application.Contracts.Movies
{
    public sealed record MovieResponse(int Id, string Title, string Description, decimal Price, int Genre);
}
