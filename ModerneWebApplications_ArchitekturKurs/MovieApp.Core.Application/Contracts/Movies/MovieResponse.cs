using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Application.Contracts.Movies
{
    public sealed record MovieResponse(int Id, string Title, string Description, decimal Price, int Genre);
}
