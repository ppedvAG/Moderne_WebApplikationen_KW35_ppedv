using MediatR;
using MovieApp.Core.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Application.Movies.Commands.UpdateMovie
{
    public sealed record UpdateMovieCommand(int MovieId, string Title, string Description, decimal Price, int Genre) : ICommand<Unit>;
}
