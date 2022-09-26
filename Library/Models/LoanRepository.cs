using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _appDbContext;

        public LoanRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Loan AddLoan(Loan loan)
        {
            loan.DateForLoan = DateTime.Now;
            var bookLoanToAdd = _appDbContext.Loans.Add(loan);
            _appDbContext.SaveChanges();
            return bookLoanToAdd.Entity;
        }
        public Loan ReturnBook(Loan loan)
        {
            throw new NotImplementedException();
        }
    }
}
