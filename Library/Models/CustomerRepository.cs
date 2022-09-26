using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CustomerRepository : ILibrary<Customer>
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Customer> GetAll
        {
            get
            {
                return _appDbContext.Customers.Include(l => l.Loans).ThenInclude(b => b.Book);
            }
        }

        public Customer Add(Customer newEntity)
        {
            var customerToAdd = _appDbContext.Customers.Add(newEntity);
            _appDbContext.SaveChanges();
            return customerToAdd.Entity;
        }

        public Customer Delete(int id)
        {
            var customerToDelete = _appDbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
            if (customerToDelete != null)
            {
                _appDbContext.Customers.Remove(customerToDelete);
                _appDbContext.SaveChanges();
                return customerToDelete;
            }
            return null;
        }

        public Customer GetSingle(int id)
        {
            return _appDbContext.Customers.Include(l => l.Loans).ThenInclude(b => b.Book).FirstOrDefault(c => c.CustomerId == id);
        }

        public Customer Update(Customer Entity)
        {
            var customerToUpdate = _appDbContext.Customers.FirstOrDefault(c => c.CustomerId == Entity.CustomerId);
            if (customerToUpdate != null)
            {
                customerToUpdate.CustomerFirstName = Entity.CustomerFirstName;
                customerToUpdate.CustomerLastName = Entity.CustomerLastName;
                customerToUpdate.PhoneNumber = Entity.PhoneNumber;

                _appDbContext.SaveChanges();
                return customerToUpdate;
            }
            return null;
        }
    }
}
