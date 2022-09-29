using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Display(Name = "Titel")]
        public string BookTitle { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Författare")]
        public string Author { get; set; }
        public int NumberAvailable { get; set; }
        [Display(Name = "Beskrivning")]
        public string? BookSubscritpion { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
