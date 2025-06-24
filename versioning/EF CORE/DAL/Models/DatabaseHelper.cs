using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DAL.Models
{
    public static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            string connectionString = builder.Build().GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
