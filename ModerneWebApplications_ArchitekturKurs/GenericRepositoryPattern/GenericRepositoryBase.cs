using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public abstract class GenericRepositoryBase<T, TKey> : IRepositoryBaseAsync<T, TKey>
        where T : class
    {
        //Kein DbContext -> mit ConnectionString von Oracle
        //Oder Kein SqlConnection, weil wir Datenbankunabhängig noch sein wollen. 
        public abstract Task AddAsync(T item);


        public abstract Task AddRangeAsync(T[] items);


        public abstract Task DeleteAsync(T entity);


        public abstract Task<IList<T>> GetAllAsync();


        public abstract Task<IList<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);


        public abstract Task<T> GetByIdAsync(TKey id);


        public abstract Task UpdateAsync(T item);


        public abstract Task UpdatesAsync(T[] items);
    }
}
