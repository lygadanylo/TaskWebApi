using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public string Email { get; set; }
    }
}