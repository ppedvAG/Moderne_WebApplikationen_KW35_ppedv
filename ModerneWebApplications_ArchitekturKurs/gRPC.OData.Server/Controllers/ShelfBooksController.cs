using gRPC.OData.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace gRPC.OData.Server.Controllers
{
    [Route("odata")]
    public class ShelfBooksController : ODataController
    {
        private readonly IShelfBookRepository _shelfBookRepository;

        public ShelfBooksController(IShelfBookRepository shelfBookRepository)
        {
            _shelfBookRepository = shelfBookRepository;
        }

        [HttpGet("Shelves")]
        [EnableQuery]
        public IActionResult ListShelves()
        {
            return Ok(_shelfBookRepository.GetShelves());
        }

        [HttpGet("Shelves/{shelf}/Books")]
        [EnableQuery]
        public IActionResult ListBooks(long shelf)
        {
            return Ok(_shelfBookRepository.GetBooks(shelf));
        }
    }
}
