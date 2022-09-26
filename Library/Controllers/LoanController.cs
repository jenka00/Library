using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILoanRepository _loanRepository;

        public LoanController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Loan loan)
        {
            _loanRepository.AddLoan(loan);
            return RedirectToAction("List");

        }
    }
}
