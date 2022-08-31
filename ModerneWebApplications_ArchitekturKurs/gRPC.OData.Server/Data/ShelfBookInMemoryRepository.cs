using Bookstores;

namespace gRPC.OData.Server.Data
{
    public class ShelfBookInMemoryRepository : IShelfBookRepository
    {
        private static IList<Shelf> _sheves;

        static ShelfBookInMemoryRepository()
        {
            IList<Book> fictions = new List<Book>
            {
                new Book { Id = 11, Title = "西游记" , Author = "吳承恩" },
                new Book { Id = 12, Title = "The Maid" , Author = "Nita Prose" },
                new Book { Id = 13, Title = "Olga Dies Dreaming" , Author = "Xochitl Gonzalez" },
                new Book { Id = 14, Title = "Violeta" , Author = "Isabel Allende" },
                new Book { Id = 15, Title = "To Paradise" , Author = "Hanya Yanagihara" },
            };

            IList<Book> classics = new List<Book>
            {
                new Book { Id = 21, Title = "To Kill a Mockingbird", Author = "Harper Lee" },
                new Book { Id = 22, Title = "Little Women", Author = "Louisa May Alcott" },
                new Book { Id = 23, Title = "Beloved", Author = "Toni Morrison" },
            };

            IList<Book> computes = new List<Book>
            {
                new Book { Id = 31, Title = "Windows 11 For Dummies", Author = "Andy Rathbone" },
                new Book { Id = 32, Title = "Code Complete", Author = "Steve McConnell"},
                new Book { Id = 32, Title = "Learning Python, 5th Edition", Author = "Mark Lutz"},
            };

            _sheves = new List<Shelf>
            {
                new Shelf
                {
                    Id = 1,
                    Theme = "Fiction",
                    Books = fictions
                },

                new Shelf
                {
                    Id = 2,
                    Theme = "Classics",
                    Books = classics
                },

                new Shelf
                {
                    Id = 3,
                    Theme = "Computer",
                    Books = computes
                }
            };
        }

        public IEnumerable<Shelf> GetShelves() => _sheves;

        public IEnumerable<Book> GetBooks(long shelfId)
        {
            Shelf shelf = _sheves.FirstOrDefault(s => s.Id == shelfId);

            if (shelf is null)
            {
                return Enumerable.Empty<Book>();
            }

            return shelf.Books;
        }
    }
}
