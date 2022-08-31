using Application.Abstractions.Messaging;
using Application.Contracts.Movies;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Commands.CreateMovie
{
    public sealed record CreateMovieCommand(int Id, string Title, string Description, decimal Price, int Genre) : ICommand<MovieResponse>;
}
