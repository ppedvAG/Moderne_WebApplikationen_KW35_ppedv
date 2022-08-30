using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public MoviesController(MovieDbContext context)
        {
            _context = context;
        }

        //https://localhost:7068/api/Movies
        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
          if (_context.Movie == null)
          {
              return NotFound();
          }
            return await _context.Movie.ToListAsync();
        }


        #region Doppelte Get-Methode in einer URL  (typischer Fehler in WebAPI )
        /* Wenn doppelte Get-Methoden auf einer URL liegen, erscheint folgende Fehler: 
         * 
         * An unhandled exception occurred while processing the request.
            AmbiguousMatchException: The request matched multiple endpoints. Matches:
            WebAPISample.Controllers.MoviesController.GetMovie (WebAPISample)
            WebAPISample.Controllers.MoviesController.GetMovie1 (WebAPISample)
         * 
         * 
         * 
         * 
         */
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Movie>>> GetMovie1()
        //{
        //    if (_context.Movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _context.Movie.ToListAsync();
        //}
        #endregion
        //https://localhost:7068/api/Movies/1
        // GET: api/Movies/5
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
          if (_context.Movie == null)
          {
              return NotFound();
          }
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }


        // https://localhost:7068/api/Movies/1
        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // https://localhost:7068/api/Movies/ -> hier wird das Movie im Http-Body mitgesenden (nicht in URL sichtbar)  

        // [FromQuery] bringt das Movie-Objekt in URL und man sieht folgendes Request ->
        // https://localhost:7068/api/Movies?Id=2&Title=Heidi&Description=von%20den%20Bergen&Price=12&GenreType=3
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
          if (_context.Movie == null)
          {
              return Problem("Entity set 'MovieDbContext.Movie'  is null.");
          }
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            //CreatedAtAction

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_context.Movie == null)
            {
                return NotFound();
            }
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return (_context.Movie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
