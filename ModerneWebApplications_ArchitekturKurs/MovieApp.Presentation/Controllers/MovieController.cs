using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Core.Application.Contracts.Movies;
using MovieApp.Core.Application.Movies.Commands.CreateMovie;
using MovieApp.Core.Application.Movies.Queries.GetMovies;
using MovieApp.Core.Application.Movies.Queries.GetMoviesById;
using MovieApp.Core.Domain.Entities;

namespace MovieApp.Presentation.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public sealed class MovieController : ControllerBase
    {
        private readonly ISender sender;

        public MovieController(ISender sender)
        {
            this.sender = sender;   
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<MovieResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMovies(CancellationToken cancellationToken)
        {
            GetMoviesQuery query = new();

            var movies = await sender.Send(query, cancellationToken);

            return Ok(movies);
        }

        [HttpGet("{movieId:int}")]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMovieById(int movieId, CancellationToken cancellationToken)
        {
            var query = new GetMovieByIdQuery(movieId);
            var movie = await sender.Send(query, cancellationToken);

            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MovieResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequest request, CancellationToken cancellationToken)
        {
            CreateMovieCommand command = request.Adapt<CreateMovieCommand>();

            MovieResponse movie = await sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetMovieById), new { movieId = movie.Id }, movie);
        }

    }
}
