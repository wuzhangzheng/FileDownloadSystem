using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using FileDownLoadSystem.Core.Extinsions;
using FileDownLoadSystem.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace FileDownLoadSystem.Core.EfDbContext
{
    public class FileDownLoadSystemDbContext : DbContext,IDependency
    {
        public FileDownLoadSystemDbContext()
        {

        }
        public FileDownLoadSystemDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                optionsBuilder.UseSqlServer("Server=172.16.1.21;database=FileDownSystem;Persist Security Info=False;MultipleActiveResultSets=False;uid=hissa;pwd=his@2018!;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=false");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                //获取所有的类库
                // DependencyContext依赖Microsoft.Extensions.DependencyModel
                var compilationLibrary = DependencyContext.Default.CompileLibraries
                .Where(x => !x.Serviceable && x.Type != "package" && x.Type == "project");
                //获取所有的数据库模型
                foreach (var _compilateon in compilationLibrary)
                {
                    //加载指定类型
                    AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(_compilateon.Name))
                    .GetTypes().Where(x => x.GetTypeInfo().BaseType != null && !x.IsAbstract && x.BaseType == (typeof(BaseModel))).ToList().ForEach(t =>
                    {
                        modelBuilder.Entity(t);
                    });
                }
            }
            catch (System.Exception)
            {
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}