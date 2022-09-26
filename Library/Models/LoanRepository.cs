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
        public Loan GetSingle(int id)
        {
            return _appDbContext.Loans.Include(b => b.Book).FirstOrDefault(l => l.LoanId == id);
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
            var loanReturnBook = _appDbContext.Loans.FirstOrDefault(l => l.LoanId == loan.LoanId);
            if(loanReturnBook != null)
            {
                loanReturnBook.DateForReturn = DateTime.Now;
                _appDbContext.SaveChanges();
                return loanReturnBook;
            }
            return null;
        }
    }
}
