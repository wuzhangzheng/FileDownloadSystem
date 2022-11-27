using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDownLoadSystem.Entity;

namespace FileDownLoadSystem.Core.BaseProvider
{
    public class BaseService<TModel,TRepository>
    where TModel:BaseModel
    where TRepository:IRepository<TModel>
    {
        protected IRepository<TModel> _repository ;
        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public TModel FindFirst()
        {
            return _repository.FindFirst(m=>m.Id==1);
        }
    }
}