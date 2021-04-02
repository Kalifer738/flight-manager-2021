using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class User
    {
        /// <summary>
        /// 
        /// </summary>
        /// 


        //required user's username for database
        [Required]
        public string UserName { get; set; }

        //required user's password for database
        [Required]
        public string Password { get; set; }

        //required user's email for database
        [Required]
        public string Email { get; set; }

        //required user's first name for database
        [Required]
        public string FirstName { get; set; }

        //required user's last name for database
        [Required]
        public string LastName { get; set; }

        //primary key user's egn for database primary key
        [Key]
        public int EGN { get; set; }

        //user's address for database
        public string Address { get; set; }

        //user's phone number for database
        public int PhoneNumber { get; set; }

        //user's role for database
        public string Role { get; set; }
    }
}
