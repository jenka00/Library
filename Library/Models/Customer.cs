using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Ange ditt förnamn")]
        [Display(Name = "Förnamn")]
        [StringLength(50, MinimumLength = 2)]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Ange ditt efternamn")]
        [Display(Name = "Efternamn")]
        [StringLength(50, MinimumLength = 2)]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Ange ditt telefonnummer")]
        [Display(Name = "Telefonnummer")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
