using CQRS_WITH_MEDIATR.Commands;
using CQRS_WITH_MEDIATR.Data.Entities;
using CQRS_WITH_MEDIATR.Notifications;
using CQRS_WITH_MEDIATR.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_WITH_MEDIATR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator mediator;

        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }   

        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            IEnumerable<Movie> moves = await mediator.Send(new GetMovieQuery()); //Query wird versendet 
            return Ok(moves);
        }

        [HttpGet("{id:int}", Name = "GetMovieById")]
        public async Task<ActionResult> GetMovieById(int id)
        {
            Movie movie = await mediator.Send(new GetMovieByIdQuery(id));

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] Movie movie)
        {
            Movie movieWithId = await mediator.Send(new AddMovieCommand(movie)); //IRequest + IRequestHandler 1:1 

            await mediator.Publish(new MovieAddedNotification(movie)); //INotification + INotificationHandler 1:N 

            return CreatedAtRoute("GetMovieById", new { id = movieWithId.Id }, movieWithId);
        }
    }
}
