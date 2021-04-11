using FlightManager.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models.Users
{
    public class UsersIndexViewModel
    {
        public PagerViewModel Pager { get; set; }

        public UsersViewModel[] Items { get; set; }
    }
}
