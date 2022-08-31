using Bookstores;

namespace gRPC.OData.Server.Data
{
    public interface IShelfBookRepository
    {
        IEnumerable<Shelf> GetShelves();

        IEnumerable<Book> GetBooks(long shelfId);
    }
}
