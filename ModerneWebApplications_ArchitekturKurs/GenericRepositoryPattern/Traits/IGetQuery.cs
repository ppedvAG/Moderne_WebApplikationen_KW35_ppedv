using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.Traits
{
    public interface IGetQueryAsync<T, TKey> where T : class
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(TKey id);

        //Parameter -> Expression<Func<T, bool>> expression -> Kann man Lambdas als Parameter verwenden 
        //list.GetByExpression(p=>p.Age > 50).ToList(); 
        Task<IList<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression);

    }

    
}
