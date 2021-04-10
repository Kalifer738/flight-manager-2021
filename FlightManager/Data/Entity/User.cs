using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FlightManager.Data.Entity
{
    public class User : IdentityUser
    {
        //required user's first name for database
        [Required]
        public string FirstName { get; set; }

        //required user's last name for database
        [Required]
        public string LastName { get; set; }

        //primary key user's egn for database 
        [Required]
        public string EGN { get; set; }

        //user's address for database
        [Required]
        public string Address { get; set; }

        //user's role for database
        [Required]
        public string Role { get; set; }
    }
}
