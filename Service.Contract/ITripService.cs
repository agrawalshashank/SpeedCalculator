using System;
using System.Collections.Generic;
using System.Text;
using Core;
using Core.Models;

namespace Service.Contract
{
    public interface ITripService
    {
        void AddTrip(Trip command);
        void DeleteTripDetails();
    }
}
