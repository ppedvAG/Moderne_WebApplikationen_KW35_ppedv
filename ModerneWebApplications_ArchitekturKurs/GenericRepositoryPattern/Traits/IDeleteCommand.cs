using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Traits
{
    public interface IDeleteCommandAsync<T> where T : class
    {
        Task DeleteAsync(T entity); 
    }
}
