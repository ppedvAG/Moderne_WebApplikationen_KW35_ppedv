using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Traits
{
    public interface IUpdateCommandAsync<T> where T : class
    {
        Task UpdateAsync(T item);
        Task UpdatesAsync(T[] items); 
    }
}
