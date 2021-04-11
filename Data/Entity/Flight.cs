using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Flight
    {
        public Flight()
        {

        }
        public Flight(string locationFrom, string locationTo, DateTime going, DateTime @return, string typeOfPlane, string nameOfAviator, int capacityOfBusinessClass, int capacityOfStandartClass, int countOfBusinessClass, int countOfStandartClass)
        {
            LocationFrom = locationFrom;
            LocationTo = locationTo;
            TypeOfPlane = typeOfPlane;
            NameOfAviator = nameOfAviator;
            CapacityOfBusinessClass = capacityOfBusinessClass;
            CapacityOfStandartClass = CapacityOfStandartClass;
            CountOfBusinessClass = countOfBusinessClass;
            CountOfStandartClass = countOfStandartClass;
        }

        public Flight(string locationFrom, string locationTo, DateTime going, DateTime @return, string typeOfPlane, string nameOfAviator, int capacityOfBusinessClass, int capacityOfStandartClass)
        {
            LocationFrom = locationFrom;
            LocationTo = locationTo;
            TypeOfPlane = typeOfPlane;
            NameOfAviator = nameOfAviator;
            CapacityOfBusinessClass = capacityOfBusinessClass;
            CapacityOfStandartClass = CapacityOfStandartClass;
        }

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
        public DateTime TakeOffTime { get; set; }

        //required passengers's return date for database
        [Required]
        public DateTime LandingTime { get; set; }

        //required plane's type for database
        [Required]
        public string TypeOfPlane { get; set; }

        //required pilot's name for database
        [Required]
        public string NameOfAviator { get; set; }

        //required plane's capacity of economy class for database
        [Required]
        public int CapacityOfStandartClass { get; set; }

        [Required]//required plane's count of business class for database
        public int CapacityOfBusinessClass { get; set; }
        
        [Required]//required plane's count of economy class for database
        public int CountOfStandartClass { get; set; }

        [Required]//required plane's capacity of business class for database
        public int CountOfBusinessClass { get; set; }
        
    }
}
