using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaggingController : ControllerBase
    {
        private readonly MovieDbContext context;

        /// <summary>
        /// Konstruktor von PaggingController
        /// </summary>
        /// <param name="context"></param>
        public PaggingController(MovieDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(int pageNumer = 1, int pageSize = 3)
        {
            if (context.Movie == null)
            {
                return NotFound();
            }

            return await context.Movie.OrderBy(e => e.Title)
                                           .Skip((pageNumer - 1) * pageSize) //streiche Datensätze
                                           .Take(pageSize).ToListAsync(); //von aktueller Stelle, nehme die nächsten x-beliebige Datensätze 
        }

        [HttpGet("PaggingVariante2")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies2(PParameters pParameters)
        {
            if (context.Movie == null)
            {
                return NotFound();
            }

            return await context.Movie.OrderBy(e => e.Title)
                                           .Skip((pParameters.PageNumber - 1) * pParameters.PageSize) //streiche Datensätze
                                           .Take(pParameters.PageSize).ToListAsync(); //von aktueller Stelle, nehme die nächsten x-beliebige Datensätze 
        }


    }

    public class PParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
