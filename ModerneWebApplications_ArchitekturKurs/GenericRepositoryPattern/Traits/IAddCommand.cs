using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Traits
{
    public interface IAddCommandAsync<T> where T : class
    {
        Task AddAsync(T item);

        Task AddRangeAsync(T[] items);
    }
}
