using JWTAuthentication.Application.Common;
using JWTAuthentication.Application.Dtos;
using JWTAuthentication.Data.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationInfrastructure.Common
{
    public class GenericRepositoryBase<T> : IGenericRepositoryBase<T> where T : class
    {
        private readonly EmsContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepositoryBase(EmsContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        #region Add
        public async Task<T> AddAsync(T entity)
        {
            await this.context.AddAsync(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }
        #endregion

        #region Delete
        public async Task DeleteByIdAsync(long Id)
        {
            var entity = await dbSet.FindAsync(Id);
            if (entity != null)
            {
                var deletedProperty = entity.GetType().GetProperty("Deleted_AT");
                if (deletedProperty != null)
                {
                    deletedProperty.SetValue(entity, DateTime.Now);
                    await context.SaveChangesAsync();
                }
            }
        }
        #endregion

        #region GetAll
        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            var queryableData = this.context.Set<T>().Where(expression);
            return await Task.FromResult(queryableData);
        }
        #endregion

        #region GetById
        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await this.context.Set<T>().FirstOrDefaultAsync(expression);

        }
        #endregion

        #region Update
        public async Task UpdateAsync(T entity)
        {
            this.context.Entry(entity).CurrentValues.SetValues(entity);
            await this.context.SaveChangesAsync();

        }
        #endregion

        #region EmailCheck
        public async Task<bool> IsEmailExists(Expression<Func<T, bool>> expression)
        {
            var entity = await this.context.Set<T>().FirstOrDefaultAsync(expression);
            return entity != null;
        }
        #endregion

        public bool CheckEmployee(long id)
        {
            return this.context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
