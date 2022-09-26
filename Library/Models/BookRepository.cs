using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class BookRepository : ILibrary<Book>
    {
        private readonly AppDbContext _appDbContext;
        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Book> GetAll
        {
            get
            {
                return _appDbContext.Books;
            }
        }

        public Book GetSingle(int id)
        {
            return _appDbContext.Books.FirstOrDefault(b => b.BookId == id);
        }
        public Book Add(Book newEntity)
        {
            throw new NotImplementedException();
        }

        public Book Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Book Update(Book Entity)
        {
            throw new NotImplementedException();
        }
    }
}
