using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Reservation
    {
        /// <summary>
        /// 
        /// </summary>
        /// 


        //required passengers's first name for database
        [Required]
        public string FirstName { get; set; }

        //required passengers's second name for database
        [Required]
        public string SecondName { get; set; }

        //required passengers's last name for database
        [Required]
        public string LastName { get; set; }

        //required primary key passengers's egn for database
        [Required]
        public int EGN { get; set; }

        //required passengers's phone number for database
        [Required]
        public int PhoneNumber { get; set; }

        //required passengers's nationality for database
        [Required]
        public string Nationality { get; set; }

        //required passengers's type of ticket for database
        [Required]
        public string TypeOfTicket { get; set; }

        //required passengers's email for database
        [Required]
        public string Email { get; set; }
    }
}
