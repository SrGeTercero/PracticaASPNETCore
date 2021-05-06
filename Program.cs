using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//Nuevos
using Microsoft.Extensions.DependencyInjection;
using Proyecto.Models;

namespace Proyecto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //ORIGINAL
            //CreateWebHostBuilder(args).Build().Run();
            
            //NUEVO, necesario para controlar en que momento se envian a crear los datos...
            
            var host = CreateWebHostBuilder(args).Build(); //se crea el web server
            
            using(var scope = host.Services.CreateScope()) //se agrega la declaracion par aque no se quede en memoria y optimizarlo, para que cumpla el ciclo de vida
            {
                var services = scope.ServiceProvider;
                try //se controla si noy hay acceso a la base de datos
                {
                    var context = services.GetRequiredService<EscuelaContext>();
                    
                    //con esto nos aseguramos que se ejecute el metod OnModelinCreating() que se 
                    //sobre escribio en la clase EscuelaContex.cs
                    context.Database.EnsureCreated();
                }
                catch(Exception ex)
                {
                    var logger  = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
