using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Flight
    {
        /// <summary>
        /// 
        /// </summary>
        /// 


        //required passengers's location from for database
        [Required]
        public string LocationFrom { get; set; }

        //required passengers's location to for database
        [Required]
        public string LocationTo { get; set; }

        //required passengers's going date for database
        [Required]
        public DateTime Going { get; set; }

        //required passengers's return date for database
        [Required]
        public DateTime Return { get; set; }

        //plane's type for database
        public string TypeOfPlane { get; set; }

        //plane's id number for database primary key
        [Key]
        public int PlaneID { get; set; }

        //pilot's name for database
        public string NameOfAviator { get; set; }

        //plane's capacity of economy class for database
        public int CapacityOfEconomyClass { get; set; }

        //plane's capacity of business class for database
        public int CapacityOfBusinessClass { get; set; }
    }
}
