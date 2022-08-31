using Application.Abstractions.Messaging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Movies.Commands.UpdateMovie
{
    public sealed record UpdateMovieCommand(int MovieId, string Title, string Description, decimal Price, int Genre) : ICommand<Unit>;
}
