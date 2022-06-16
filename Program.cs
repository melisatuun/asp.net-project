using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using project.Models;

namespace project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        
            using (var db = new SchoolContext()) 
            {
                db.Add(new School { Name = "Bilkent" });
                db.SaveChanges();

                var bilkent = db.Schools
                    .OrderBy(b => b.Id)
                    .Last();
                
                bilkent.Students.Add(new Student { Name = "Amerikan" });
                db.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
