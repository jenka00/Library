using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 1,
                BookTitle = "Kallmyren",
                ImageUrl = "\\Images\\Kallmyren.jpg",
                Author = "Liza Marklund",
                NumberAvailable = 2                
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 2,
                BookTitle = "Natriumklorid",
                ImageUrl = "\\Images\\Natriumklorid.jpg",
                Author = "Jussi Adler Olsen",
                NumberAvailable = 1
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 3,
                BookTitle = "Agenturen",
                ImageUrl = "\\Images\\Agenturen.jpg",
                Author = "Christina Larsson",
                NumberAvailable = 2
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 4,
                BookTitle = "Svartfågel",
                ImageUrl = "\\Images\\Svartfagel.jpg",
                Author = "Frida Skybäck",
                NumberAvailable = 3
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 5,
                BookTitle = "Spegelmannen",
                ImageUrl = "\\Images\\Spegelmannen.jpg",
                Author = "Lars Keppler",
                NumberAvailable = 2
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                CustomerFirstName = "Anna",
                CustomerLastName = "Andersson",
                PhoneNumber = "0723456789"
            }); 
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                CustomerFirstName = "Björn",
                CustomerLastName = "Andersson",
                PhoneNumber = "0723456790"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                CustomerFirstName = "Albin",
                CustomerLastName = "Karlsson",
                PhoneNumber = "0729876543"
            });
        }
    }
}
