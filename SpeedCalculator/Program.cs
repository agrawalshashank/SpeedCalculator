using Core.Factories;
using Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Contract;
using Service;
using Service.Contract;
using System;

namespace SpeedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup DI
            ServiceProvider configureService = ConfigureService();

            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToLower().Contains("report"))
                {
                    break;
                }

                var command = CommandFactory.Create(input);
                if (command == null || !command.Validate())
                {
                    Console.WriteLine("Command is not in proper format.");
                    Console.WriteLine("Generating report for other drivers entered");
                    return;                    
                }
                else
                {
                    if (command is Driver)
                    {
                        var driverService = configureService.GetService<IDriverService>();
                        driverService.RegisterDriver(command as Driver);
                    }
                    else if (command is Trip)
                    {
                        var tripService = configureService.GetService<ITripService>();
                        tripService.AddTrip(command as Trip);
                    }
                }
            }

            var reportService = configureService.GetService<IReportService>();
            Console.WriteLine(reportService.GenerateReport());
            configureService.Dispose();
            Console.ReadLine();
        }

        private static ServiceProvider ConfigureService()
        {
            return new ServiceCollection()
                .AddTransient<IDriverService, DriverService>()
                .AddTransient<ITripService, TripService>()
                .AddTransient<IReportService, ReportService>()
                .AddTransient<IIdCreator, IdRepository>()
                .AddTransient(typeof(IRepository<>), typeof(RepositoryBaseJSON<>))
                .BuildServiceProvider();
        }        
    }
}
