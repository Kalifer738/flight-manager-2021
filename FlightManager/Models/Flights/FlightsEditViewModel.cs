﻿using Data.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FlightManager.Models.Flights
{
    public class FlightsEditViewModel
    {

        public FlightsEditViewModel(Flight flight)
        {
            Id = flight.Id;
            CapacityOfBusinessClass = flight.CapacityOfBusinessClass;
            CapacityOfStandartClass = flight.CapacityOfStandartClass;
            Going = flight.TakeOffTime;
            Return = flight.LandingTime;
            LocationFrom = flight.LocationFrom;
            LocationTo = flight.LocationTo;
            NameOfAviator = flight.NameOfAviator;
            TypeOfPlane = flight.TypeOfPlane;
        }
        /// <summary>
        /// administrator and employee can edit flights  
        /// the data is entered automatically by planeId 
        /// </summary>

        //accesses the data by id
        public int Id { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter where the plane will take off.")]
        //initiation data input by administrator for location 
        public string LocationFrom { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter where the plane will land from.")]
        //initiation data input by administrator for location
        public string LocationTo { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter when it will go.")]
        [DataType(DataType.DateTime)]
        //initiation data input by administrator for time to go
        public DateTime Going { get; set; }

        //checks if the field is empty
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Enter when it will arrive.")]
        //initiation data input by administrator for time to arrive 
        public DateTime Return { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter type of plane.")]
        //initiation data input by administrator for type of plane 
        public string TypeOfPlane { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Aviator's name is required.")]
        //initiation data input by administrator for aviator's name
        public string NameOfAviator { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter capacity of economy class.")]
        //initiation data input by administrator for capacity of economy
        public int CapacityOfStandartClass { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter capacity of bussiness class.")]
        //initiation data input by administrator for capacity of bussiness
        public int CapacityOfBusinessClass { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter capacity of economy class.")]
        //initiation data input by administrator for capacity of economy
        public int CountOfStandartClass { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Enter capacity of bussiness class.")]
        //initiation data input by administrator for capacity of bussiness
        public int CountOfBusinessClass { get; set; }
    }
}