using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS
{
    public static class ModelsSetting
    {
        public static string GetConnectionString()
        {
            var Configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
            .Build();

            return Configuration.GetConnectionString("DefaultConnection");
        }
    }
}
