using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateForLoan { get; set; } 

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime? DateForReturn { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        
    }
}
