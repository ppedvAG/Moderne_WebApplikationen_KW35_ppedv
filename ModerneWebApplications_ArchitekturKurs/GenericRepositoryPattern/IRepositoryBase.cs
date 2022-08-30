using GenericRepositoryPattern.Traits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public interface IRepositoryBaseAsync<T, TKey> : IGetQueryAsync<T, TKey>, IUpdateCommandAsync<T>, IAddCommandAsync<T>, IDeleteCommandAsync<T>
        where T : class
    {

    }
}
