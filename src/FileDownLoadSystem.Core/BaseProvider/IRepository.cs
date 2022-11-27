using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FileDownLoadSystem.Entity;

namespace FileDownLoadSystem.Core.BaseProvider
{
    public interface IRepository<TModel> where TModel:BaseModel
    {
        IQueryable<TModel> FindAsIQueryable(Expression<Func<TModel, bool>> predicate);
        TModel FindFirst(Expression<Func<TModel, bool>> predicate);
    }
}