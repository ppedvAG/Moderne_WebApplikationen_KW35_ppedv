using Bookstores;
using Google.Protobuf.WellKnownTypes;
using gRPC.OData.Server.Data;
using Grpc.Core;

namespace gRPC.OData.Server.Services
{
    public class BookstoreService : Bookstore.BookstoreBase
    {
        private readonly ILogger _logger;

        private readonly IShelfBookRepository _shelfBookRepository;

        public BookstoreService(ILoggerFactory loggerFactory, IShelfBookRepository shelfBookRepository)
        {
            _logger = loggerFactory.CreateLogger<BookstoreService>();

            _shelfBookRepository = shelfBookRepository;
        }

        public override Task<ListShelvesResponse> ListShelves(Empty request, ServerCallContext context)
        {
            IEnumerable<Shelf> shelves = _shelfBookRepository.GetShelves();

            ListShelvesResponse response = new ListShelvesResponse();
            foreach (var shelf in shelves)
            {
                response.Shelves.Add(shelf);
            }

            return Task.FromResult(response);
        }

        // list the books
        public override Task<ListBooksResponse> ListBooks(ListBooksRequest request, ServerCallContext context)
        {
            IEnumerable<Book> books = _shelfBookRepository.GetBooks(request.Shelf);

            ListBooksResponse response = new ListBooksResponse();
            foreach (Book book in books)
            {
                response.Books.Add(book);
            };

            return Task.FromResult(response);
        }
    }
}
