using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CustomerOptions : ViewComponent
    {
        private readonly ILibrary<Customer> _customerRepository;

        public CustomerOptions(ILibrary<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IViewComponentResult Invoke()
        {
            var customer = _customerRepository.GetAll;
            return View(customer);
        }
    }
}
