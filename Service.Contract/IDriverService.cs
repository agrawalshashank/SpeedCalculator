using Core.Models;
using System;

namespace Service.Contract
{
    public interface IDriverService
    {
        void RegisterDriver(Driver command);
        bool IsDriverExists(string driverName);
        void DeleteDriverDetails();
    }
}
