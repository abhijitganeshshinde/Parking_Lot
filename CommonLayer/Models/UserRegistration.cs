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
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write UserType")]
        [RegularExpression(@"^Admin|^Security$|^Police$|^Driver$")]
        public string User_Type { get; set; }

        [Required(ErrorMessage = "Wrong Field Name Please Write Password")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
