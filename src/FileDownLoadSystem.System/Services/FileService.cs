using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileDownLoadSystem.Core.BaseProvider;
using FileDownLoadSystem.Entity.FileInfo;
using FileDownLoadSystem.System.IRepositories;
using FileDownLoadSystem.System.IServices;
using FileDownLoadSystem.System.Repositories;

namespace FileDownLoadSystem.System.Services
{
    public class FileService : BaseService<Files, IFileRepository>,IFileService
    {
        public FileService(IFileRepository repository) : base(repository)
        {
        }
    }
}