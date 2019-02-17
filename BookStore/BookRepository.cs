using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using Dapper;
using System;

namespace BookStore
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DapperConnection"].ConnectionString;
        public IEnumerable<Book> GetAllBooks()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Book>("BooksAll");
            }
        }

        public Book Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Book>("SELECT * FROM Books WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Book book)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                    var sqlQuery = "INSERT INTO Books (Name, Author, PageCount) VALUES(@Name, @Author, @PageCount); SELECT CAST(SCOPE_IDENTITY() as int)";
                    int userId = db.Query<int>(sqlQuery, book).First();
                    book.Id = userId;
                
            }
        }

        public void Update(Book book)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Books SET Name = @Name, Author = @Author, PageCount = @PageCount,Email = @Email WHERE Id = @Id";
                db.Execute(sqlQuery, book);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Books WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}