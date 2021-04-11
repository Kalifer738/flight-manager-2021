using FlightManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Flights
{
    public class FlightsIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public FlightsViewModel[] Items { get; set; }
    }
}
