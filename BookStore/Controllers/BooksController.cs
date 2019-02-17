using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;

namespace BookStore.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookRepository _bookRepository = new BookRepository();
        // GET: api/Books
        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAllBooks();
        }

        // GET: api/Books/5
        public Book Get(int id)
        {
            return _bookRepository.Get(id);
        }

        // POST: api/Books
        public IHttpActionResult Post([FromBody]Book book)
        {
            _bookRepository.Create(book);
            return Created(Request.RequestUri + book.Id.ToString(), book);
        }

        // PUT: api/Books/5
        public IHttpActionResult Put(int id, [FromBody]Book book)
        {
            book.Id = id;
            _bookRepository.Update(book);
            return Ok();
        }

        // DELETE: api/Books/5
        public IHttpActionResult Delete(int id)
        {
            _bookRepository.Delete(id);
            return Ok();
        }
    }
}
