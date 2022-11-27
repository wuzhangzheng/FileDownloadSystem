using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FileDownLoadSystem.Core.EfDbContext;
using FileDownLoadSystem.Entity;
using Microsoft.EntityFrameworkCore;

namespace FileDownLoadSystem.Core.BaseProvider
{
    public class BaseRepository<TModel> where TModel:BaseModel
    {
        private readonly FileDownLoadSystemDbContext _defaultDbContext;

        public BaseRepository(FileDownLoadSystemDbContext dbContext)
        {
            this._defaultDbContext = dbContext;
        }
        public FileDownLoadSystemDbContext DbContext=>_defaultDbContext;
        private DbSet<TModel> DbSet=>_defaultDbContext.Set<TModel>();
        public virtual TModel FindFirst(Expression<Func<TModel,bool>> predicate){
            return FindAsIQueryable(predicate).FirstOrDefault();
        }
        public IQueryable<TModel> FindAsIQueryable(Expression<Func<TModel, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
    }
} 