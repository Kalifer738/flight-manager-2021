using System;

namespace flight_manager_2021.Models.Flights
{
    public class FlightsViewModel
    {
        public string LocationFrom { get; set; }

        public string LocationTo { get; set; }

        public DateTime Going { get; set; }

        public DateTime Return { get; set; }

        public string TypeOfPlane { get; set; }

        public int PlaneID { get; set; }

        public string NameOfAviator { get; set; }

        public int CapacityOfEconomyClass { get; set; }

        public int CapacityOfBusinessClass { get; set; }
    }
}
