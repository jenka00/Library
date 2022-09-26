using Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class LoanViewModel
    {        
        public Customer Customer { get; set; }
        public Book Book { get; set; }
        public IEnumerable<Loan> LoanList { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Återlämningsdatum")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReturnDate { get; set; }
    }
}
