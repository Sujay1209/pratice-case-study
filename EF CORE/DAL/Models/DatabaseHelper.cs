using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DAL.Models
{
    public static class DatabaseHelper
    {
        private static IConfigurationRoot configuration;

        static DatabaseHelper()
        {
            // Build configuration from appsettings.json
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // For console app or project root
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string GetConnectionString()
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
