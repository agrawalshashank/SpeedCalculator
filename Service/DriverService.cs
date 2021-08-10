using Core.Models;
using Persistence.Contract;
using Service.Contract;
using System;
using System.Linq;

namespace Service
{
    public class DriverService : IDriverService
    {
        private readonly IRepository<Driver> driverRepository;
        private readonly IIdCreator idCreator;

        public DriverService(IRepository<Driver> driverRepository, IIdCreator idCreator)
        {
            this.driverRepository = driverRepository;
            this.idCreator = idCreator;
        }

        public void DeleteDriverDetails()
        {
            driverRepository.DeleteByClass<Driver>();
        }

        public bool IsDriverExists(string driverName)
        {
            return driverRepository.GetAll().Any(x => x.DriverName.ToLower() == driverName.ToLower());
        }

        public void RegisterDriver(Driver command)
        {
            command.Id = idCreator.CreateId();
            driverRepository.Save(command);
        }
    }
}
