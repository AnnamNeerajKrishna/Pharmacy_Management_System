using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy_Management_System.Model
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set;}
        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage ="Name Should not bee Empty")]
        public string SupplierName { get; set;}

        [Required]
        [Column(TypeName = "varchar(35)")]
        [MinLength(8)]
        public string EmailID { get; set;}

        // [Phone]
      //  [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        
        public string Contact { get; set;}

        [Required]
        [Column(TypeName = "varchar(25)")]
        public string DrugAvailable { get; set;}
    }
}
