using Bookstores;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPC.OData.Client
{
    internal class GrpcBookstoreClient
    {
        private readonly string _baseUri;

        public GrpcBookstoreClient(string baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task ListShelves()
        {
            Console.WriteLine("\ngRPC: List shelves:");

            using var channel = GrpcChannel.ForAddress(_baseUri);
            var client = new Bookstore.BookstoreClient(channel);

            var listShelvesResponse = await client.ListShelvesAsync(new Empty());
            foreach (var shelf in listShelvesResponse.Shelves)
            {
                Console.WriteLine($"\t-{shelf.Id}): {shelf.Theme}");
            }

            Console.WriteLine();
        }

        public async Task ListBooks(long shelfId)
        {
            Console.WriteLine($"\ngRPC: List books at shelf '{shelfId}':");

            using var channel = GrpcChannel.ForAddress(_baseUri);
            var client = new Bookstore.BookstoreClient(channel);

            var listBooksResponse = await client.ListBooksAsync(new ListBooksRequest { Shelf = shelfId });
            foreach (var book in listBooksResponse.Books)
            {
                Console.WriteLine($"\t-{book.Id}): <<{book.Title}>> by {book.Author}");
            }
        }
    }
}
