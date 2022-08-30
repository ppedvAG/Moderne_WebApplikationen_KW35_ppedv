using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern.EfCore
{

    //T = Tabellennamen oder EntityTyp
    //TKey = int oder Guid sein.
    public class EfCoreRepositoryBase<T, TKey> 
        : GenericRepositoryBase<T, TKey> where T : class
    {
        protected DbContext dbContext;

        public EfCoreRepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public override async Task AddAsync(T item)
        {
            await dbContext.Set<T>().AddAsync(item);
            await dbContext.SaveChangesAsync(); //Wenn wir ohne UnitOfWork arbeiten 
        }

        public override async Task AddRangeAsync(T[] items)
        {
            await dbContext.Set<T>().AddRangeAsync(items);
            await dbContext.SaveChangesAsync();
        }

        public override async Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public override async Task<IList<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public override async Task<IList<T>> GetByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await dbContext.Set<T>().Where(expression).ToListAsync();
        }

        public override async Task<T> GetByIdAsync(TKey id)
        {
            //Was für ein Datentyp ist der Key
            T? returnObject = null;

            if (id  is int integerKey)
            {
                returnObject = await dbContext.Set<T>().FindAsync(integerKey);
            }
            else if (id is Guid guidKey)
            {
                returnObject = await dbContext.Set<T>().FindAsync(guidKey);
            }
            

            if (returnObject == null)
                throw new Exception();

            return returnObject;
        }

        public override async Task UpdateAsync(T item)
        {
            dbContext.Update(item);
            await dbContext.SaveChangesAsync(); 
        }

        public override async Task UpdatesAsync(T[] items)
        {
            foreach(T item in items)
                dbContext.Update(item);

            await dbContext.SaveChangesAsync();
        }
    }
}
