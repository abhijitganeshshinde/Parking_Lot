using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Models
{
    public class UserRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write Email")]
        [EmailAddress(ErrorMessage = "Email Should Be Like Ex:- xyz@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write UserType")]
        [RegularExpression(@"^Admin|^Security$|^Police$|^Driver$", ErrorMessage = "User Type Is Admin , Security , Police And Driver")]
        public string User_Type { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write Password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Please Enter Minimum 6 Letters ")]
        public string Password { get; set; }
    }
}
