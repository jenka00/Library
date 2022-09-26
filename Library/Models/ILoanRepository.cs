using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public interface ILoanRepository
    {
        Loan GetSingle(int id);
        Loan AddLoan(Loan loan);
        Loan ReturnBook(Loan loan);        
    }
}
