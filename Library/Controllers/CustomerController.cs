using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILibrary<Customer> _customerRepository;

        public CustomerController(ILibrary<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult List()
        {
            IEnumerable<Customer> customerList = _customerRepository.GetAll;
            return View(customerList);
        }
        public IActionResult Details(int id)
        {
            var customerToView = _customerRepository.GetSingle(id);
            if (customerToView == null)
            {
                return NotFound();
            }
            return View(customerToView);
        }
        
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Add(customer);
                return RedirectToAction("List");
            }
            return View(customer);
        }
        //GET
        public IActionResult Edit(int id)
        {
            var customerToUpdate = _customerRepository.GetSingle(id);
            if (customerToUpdate == null)
            {
                return NotFound();
            }
            return View(customerToUpdate);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Update(customer);
                return RedirectToAction("List");
            }
            return View(customer);
        }
        //GET
        public IActionResult Remove(int id)
        {
            var customerToUpdate = _customerRepository.GetSingle(id);
            if (customerToUpdate == null)
            {
                return NotFound();
            }
            return View(customerToUpdate);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveCustomer(int id)
        {
            var customerToDelete = _customerRepository.Delete(id);
            if(customerToDelete == null)
            {
                return NotFound();
            }
            return RedirectToAction("List");
        }  
    }
}
