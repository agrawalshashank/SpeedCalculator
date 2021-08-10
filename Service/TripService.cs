using Core.Models;
using Persistence.Contract;
using Service.Contract;
using System;

namespace Service
{
    public class TripService : ITripService
    {
        private readonly IDriverService driverService;
        private readonly IRepository<Trip> tripRepository;
        private readonly IIdCreator idCreator;

        public TripService(IDriverService driverService, IRepository<Trip> tripRepository, IIdCreator idCreator)
        {
            this.driverService = driverService;
            this.tripRepository = tripRepository;
            this.idCreator = idCreator;
        }

        public void AddTrip(Trip command)
        {
            //Check if driver is present in the list 
            if (driverService.IsDriverExists(command.Driver.DriverName))
            {
                var speed = CalculateSpeed(command);
                if (ValidateSpeed(speed))
                {
                    //Add trip to the driver
                    command.Id = idCreator.CreateId();
                    tripRepository.Save(command);
                }
            }
        }

        private bool ValidateSpeed(decimal speed)
        {
            if (speed < 5 || speed > 100)
            {
                return false;
            }

            return true;
        }

        private decimal CalculateSpeed(Trip command)
        {
            var duration = command.EndTime - command.StartTime;
            var timeTaken = duration.TotalHours;

            return command.DistanceCovered / Convert.ToDecimal(timeTaken);
        }

        public void DeleteTripDetails()
        {
            tripRepository.DeleteByClass<Trip>();
        }
    }
}
