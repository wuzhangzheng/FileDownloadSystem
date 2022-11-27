using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDownLoadSystem.Core.BaseProvider;
using FileDownLoadSystem.Core.Extinsions;
using FileDownLoadSystem.Entity.FileInfo;

namespace FileDownLoadSystem.System.IServices
{
    public interface IFileService:IService<Files>,IDependency
    {
        
    }
}