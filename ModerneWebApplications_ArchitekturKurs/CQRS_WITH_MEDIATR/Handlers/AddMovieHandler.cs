using CQRS_WITH_MEDIATR.Commands;
using CQRS_WITH_MEDIATR.Data;
using CQRS_WITH_MEDIATR.Data.Entities;
using MediatR;

namespace CQRS_WITH_MEDIATR.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, Movie>
    {
        private readonly FakeDataStore _fakeDataStore;

        public AddMovieHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<Movie> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddMovie(request.Movie);

            return request.Movie;
        }
    }
}
