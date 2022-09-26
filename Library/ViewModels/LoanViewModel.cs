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
        public Customer customer { get; set; }
        public IEnumerable<Book> BookList { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Lånedatum")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime loanDate { get; set; }
    }
}
