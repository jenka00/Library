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
            return RedirectToAction("Index", "Home");
        }

        //GET
        public IActionResult Edit(int id)
        {
            var loanToReturn = _loanRepository.GetSingle(id);
            if (loanToReturn == null)
            {
                return NotFound();
            }
            return View(loanToReturn);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Loan loan)
        {
            if (ModelState.IsValid)
            {
                _loanRepository.ReturnBook(loan);
                return RedirectToAction("Index", "Home");
            }
            return View(loan);
        }
    }
}
