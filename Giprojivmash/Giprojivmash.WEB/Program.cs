using System;
using System.IO;
using Giprojivmash.DAL.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Giprojivmash.WEB
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1118:Utility classes should not have public constructors", Justification = "<>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
    public class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<>")]
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var context = new GiprojivmashContext(ConnectionString()))
            {
                try
                {
                    GiprojivmashInitializer.InitializerAsync(context);
                }
                catch (Exception ex)
                {
                    string path = Directory.GetCurrentDirectory() + "\\Log.txt";
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(DateTime.Now);
                        sw.WriteLine(ex);
                        sw.WriteLine("ConnectionString: " + ConnectionString());
                        sw.WriteLine("--------------------------------------------------------------");
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static string ConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            return config.GetConnectionString("GiprojivmashConnection");
        }
    }
}
