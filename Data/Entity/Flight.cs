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


        //primary key
        [Key]
        public int Id { get; set; }

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

        //required plane's type for database
        [Required]
        public string TypeOfPlane { get; set; }

        //required plane's id number for database primary key
        [Required]
        public int PlaneID { get; set; }

        //required pilot's name for database
        [Required]
        public string NameOfAviator { get; set; }

        //required plane's capacity of economy class for database
        [Required]
        public int CapacityOfEconomyClass { get; set; }

        //required plane's capacity of business class for database
        [Required]
        public int CapacityOfBusinessClass { get; set; }
    }
}
