using System;

namespace FlightManager.Models.Flights
{
    public class FlightsViewModel
    {
        public int Id { get; set; }

        public string LocationFrom { get; set; }

        public string LocationTo { get; set; }

        public DateTime Going { get; set; }

        public DateTime Return { get; set; }

        public string TypeOfPlane { get; set; }

        public string NameOfAviator { get; set; }

        public int CapacityOfStandartClass { get; set; }

        public int CapacityOfBusinessClass { get; set; }

        public int CountOfStandartClass { get; set; }

        public int CountOfBusinessClass { get; set; }
    }
}
