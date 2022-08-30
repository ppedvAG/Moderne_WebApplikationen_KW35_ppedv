using CQRS_WITH_MEDIATR.Data;
using CQRS_WITH_MEDIATR.Data.Entities;
using CQRS_WITH_MEDIATR.Queries;
using MediatR;

namespace CQRS_WITH_MEDIATR.Handlers
{
    public class GetMovieHandler : IRequestHandler<GetMovieQuery, IEnumerable<Movie>>
    {

        private readonly FakeDataStore _fakeDataStore;

        public GetMovieHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }


        /// <summary>
        /// Hier kann ich mein Query 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IEnumerable<Movie>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetAllMovies();
        }
    }
}
