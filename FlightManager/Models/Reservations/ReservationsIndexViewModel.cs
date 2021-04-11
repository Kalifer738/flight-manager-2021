using FlightManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Reservations
{
    public class ReservationsIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public ReservationsViewModel[] Items { get; set; }
    }
}
