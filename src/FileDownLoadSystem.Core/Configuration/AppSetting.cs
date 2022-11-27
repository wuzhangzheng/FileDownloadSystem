using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileDownLoadSystem.Core.Configuration
{
    public class AppSetting
    {
        public static Dictionary<string, string> Connections { get; set; }
        private static Connection _connection;
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            _connection = configuration.GetSection("Connection").Get<Connection>();
        }
    }
}