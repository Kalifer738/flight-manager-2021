using System;
using System.ComponentModel.DataAnnotations;

namespace flight_manager_2021.Models.Users
{
    public class UsersEditViewModel
    {
        /// <summary>
        /// administrator can edit empolyee's profiles  
        /// the data is entered automatically by EGN 
        /// </summary>

        //checks if the field is empty
        [Required(ErrorMessage = "User name is required.")]
        //initiation data input by administrator for username
        public string UserName { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Password is required.")]
        //initiation data input by administrator for password 
        public string Password { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Email is required.")]
        //checks for valid email
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Incorrect email")]
        //initiation data input by administrator for email
        public string Email { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "First name is required.")]
        //initiation data input by administrator for empolyee's first name 
        public string FirstName { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Last name is required.")]
        //initiation data input by administrator for empolyee's last name 
        public string LastName { get; set; }

        public int EGN { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Address is required.")]
        //initiation data input by administrator for empolyee's address
        public string Address { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Phone number is required.")]
        //checks for valid phone number
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Incorrect phone number")]
        //initiation data input by administrator for empolyee's phone number
        public int PhoneNumber { get; set; }

        //checks if the field is empty
        [Required(ErrorMessage = "Role is required.")]
        //initiation data input by administrator for empolyee's role
        public string Role { get; set; }
    }
}
