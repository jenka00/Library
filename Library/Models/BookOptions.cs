using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookOptions : ViewComponent
    {
        private readonly ILibrary<Book> _bookRepository;

        public BookOptions(ILibrary<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IViewComponentResult Invoke()
        {
            var books = _bookRepository.GetAll;
            return View(books);
        }
    }
}
