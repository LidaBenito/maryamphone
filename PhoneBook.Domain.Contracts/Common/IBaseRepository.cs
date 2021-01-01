using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBook.Domain.Contracts.Common
{
    public interface IBaseRepository<TEntity> where TEntity:BaseEntity,new()
    {
        IQueryable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        TEntity Get(int id);
        void Delete(int id);


    }
}
