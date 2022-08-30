using CQRS_WITH_MEDIATR.Data;
using CQRS_WITH_MEDIATR.Data.Entities;
using CQRS_WITH_MEDIATR.Queries;
using MediatR;

namespace CQRS_WITH_MEDIATR.Handlers
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly FakeDataStore fakeDataStore;

        public GetMovieByIdHandler(FakeDataStore fakeDataStore)
        {
            this.fakeDataStore = fakeDataStore;
        }
        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await fakeDataStore.GetMovieById(request.Id);
        }
    }
}
