using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPISample.Data;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    //https://localhost:12345/api/[NameDesControllers] 
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnTypesController : ControllerBase
    {
        private readonly MovieDbContext dbContext;

        public ReturnTypesController(MovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public string GetHelloWorld()
        {
            //gibt einen String zurück
            return "Hello World";
        }

        //[HttpGet("/GetCurrentTime")] -> fängt eer Root wieder an -> https://localhost:12345/GetCurrentTime
        //[HttpGet("GetCurrentTime")] -> erweitert die bestehende URL -> https://localhost:12345/ReturnTypes/GetCurrentTime
        [HttpGet("GetCurrentTime")]
        public ContentResult GetCurrentTime()
        {
            //Content gibt auch einen String zurück
            return Content(DateTime.Now.ToString());
        }

        //Complexe Objecte
        [HttpGet("GetComplexObject")]
        public Movie GetMovie()
        {
            return new Movie() { Id = 1, Title = "Mr. Bean", Description = "Comedian", Price = 10, GenreType = GenreType.Comedy };
        }

        /*
         *  IActionResult: Wird verwendet bei -> HttpPut / HttpDelete / HttpPost (nur, wenn kein Datensatz in der Response vorliegen soll) 
         *  ActionResult: Wird verwendet bei HttpGet / HttpPost (nur, wenn ein Datensatz in der Response vorliegen soll) 
         * 
         * 
         * 
         */ 

        #region ActionResult + IActionResult -> Synchrone Methoden
        [HttpGet("GetMovie_IActionResult")]
        //IActionResult wird bei HttpPost / HttpPut / HttpDelete
        public IActionResult GetMovie_IActionResult()
        {
            Movie movie = new Movie() { Id = 1, Title = "Mr. Bean", Description = "Comedian", Price = 10, GenreType = GenreType.Comedy };

            if (movie.Id == 1)
                return NotFound("Datensatz wurde nicht gefunden");

            return Ok();
        }


        [HttpGet("GetMovie_ActionResult")]
        //ActionResult wird bei HttpGet verwendet
        public ActionResult GetMovie_ActionResult()
        {
            Movie movie = new Movie() { Id = 1, Title = "Mr. Bean", Description = "Comedian", Price = 10, GenreType = GenreType.Comedy };

            if (movie.Id == 1)
                return NotFound("Datensatz wurde nicht gefunden");

            return Ok();
        }
        #endregion


        #region ActionResult + IActionResult -> Asynchrone Methoden
        [HttpGet("GetMovie_IActionResultAsync")]
        public async Task<IActionResult> GetMovie_IActionResultAsync()
        {
            object id = 1;
            Movie movie = await dbContext.Movie.FirstAsync(m => m.Id == 1);
            return Ok(movie);
        }

        [HttpGet("GetMovie_ActionResultAsync")]
        public async Task<ActionResult> GetMovie_ActionResultAsync()
        {
            Task myWaitingTask = Task.Delay(1000);
            myWaitingTask.Wait();


            object id = 1;
            Movie movie = await dbContext.Movie.FirstAsync(m => m.Id == 1);
            return Ok(movie);
        }

        //https://docs.microsoft.com/de-de/aspnet/core/web-api/action-return-types?view=aspnetcore-6.0
        [HttpGet("MovieSyncsale")]
        public IEnumerable<Movie> GetOnSaleProducts()
        {
            var movies = dbContext.Movie.ToList();

            foreach (var movie in movies)
            {
                yield return movie;
            }
        } //hier verlassen wir die Methode


        [HttpGet("MovieAsyncsale")]
        public async IAsyncEnumerable<Movie> GetOnSaleProductsAsync()
        {
            IAsyncEnumerable<Movie> movies = dbContext.Movie.AsAsyncEnumerable();

            await foreach (var movie in movies)
            {
                yield return movie;
            }
        }

        #endregion


    }
}
