using gRPC.OData.Client;
using Bookstores;


string baseUri = "https://localhost:7064";


GrpcBookstoreClient gRPCbookStore = new GrpcBookstoreClient(baseUri);
await gRPCbookStore.ListShelves();
await gRPCbookStore.ListBooks(2);

ODataBookstoreClient oDataBookStore = new ODataBookstoreClient(baseUri);
await oDataBookStore.ListShelves();
await oDataBookStore.ListBooks(2);

Console.ReadLine();
