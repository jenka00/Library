using Library.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly ILibrary<Book> _bookRepository;

        public BookController(ILibrary<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult List()
        {
            return View(_bookRepository.GetAll);
        }
        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetSingle(id);
            if(book == null)
            {
                return NotFound();
            }
            return View(book);
        }
    }
}
