using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Domain;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameState gameState = new GameState(new string[] {"Olmo", "Bram", "Jasper"});
            JsonProcessor jsonProcessor = new JsonProcessor();
            Console.WriteLine(jsonProcessor.getVillagerJson(gameState));
            Console.WriteLine(jsonProcessor.getWerewolfJson(gameState));
            Console.WriteLine(gameState.getPlayerNames()[0]);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
