using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace BookStore
{
    public interface IBookRepository
    {
        void Create(Book book);
        void Delete(int id);
        Book Get(int id);
        IEnumerable<Book> GetAllBooks();
        void Update(Book book);
    }
}
