using Application.Contracts.Movies;
using Application.Movies.Commands.CreateMovie;
using Application.Movies.Commands.UpdateMovie;
using Application.Movies.Queries.GetMovies;
using Application.Movies.Queries.GetMoviesById;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class MoveController : ControllerBase
    {
        private readonly ISender _sender;

        public MoveController(ISender sender) => _sender = sender;


        /// <summary>
        /// Gets all of the users.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The collection of users.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<MovieResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMovies(CancellationToken cancellationToken)
        {
            GetMoviesQuery query = new GetMoviesQuery();

            var users = await _sender.Send(query, cancellationToken);

            return Ok(users);
        }

        [HttpGet("{movieId:int}")]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovieById(int movieId, CancellationToken cancellationToken)
        {
            var query = new GetMovieByIdQuery(movieId);

            var user = await _sender.Send(query, cancellationToken);

            return Ok(user);
        }


        [HttpPost]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
        {
            CreateMovieCommand command = request.Adapt<CreateMovieCommand>();

            MovieResponse movie = await _sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetMovieById), new { movieId = movie.Id }, movie);
        }


        [HttpPut("{movieId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMovie(int movieId, [FromBody] UpdateMovieRequest request, CancellationToken cancellationToken)
        {
            var command = request.Adapt<UpdateMovieCommand>() with
            {
                MovieId = movieId
            };

            await _sender.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
