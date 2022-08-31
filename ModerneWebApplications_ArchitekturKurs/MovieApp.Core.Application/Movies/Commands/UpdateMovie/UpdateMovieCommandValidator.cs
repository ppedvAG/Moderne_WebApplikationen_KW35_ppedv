using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Application.Movies.Commands.UpdateMovie
{
    
    public sealed class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.MovieId).NotEmpty();

            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Description).NotEmpty().MaximumLength(150);

            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).LessThan(99);

            RuleFor(x => x.Genre).NotEmpty();
        }
    }
}
