using PhoneBook.Domain.Contracts.Common;
using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Infarstructure.DAL.Common
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly PhoneBookMaryaContext dbContext;

        public BaseRepository(PhoneBookMaryaContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TEntity Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            dbContext.Remove(entity);

        }

        public TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsQueryable();
        }
    }

}