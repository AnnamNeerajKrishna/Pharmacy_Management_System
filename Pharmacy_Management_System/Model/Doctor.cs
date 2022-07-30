using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management_System.Model
{
    public class Doctor
    {
        [Key]
        [Column(TypeName ="varchar(25)")]
        public string DoctorId { get; set; }

        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage ="Name cannot be empty")]
        public string DoctorName { get; set; }

        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "Phone Number cannot be empty")]
        public string Contact { get; set; }

        [Required]
        [Column(TypeName = "varchar(35)")]
        [MinLength(7,ErrorMessage ="Please Enter a Valid Input")]
        public string EmailID { get; set; }

        [Required]
        [Column(TypeName = "varchar(225)")]
        public string Password { get; set; } 

        public string Address { get; set; }

    }
}
