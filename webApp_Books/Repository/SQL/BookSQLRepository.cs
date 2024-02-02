using webApp_Books.Data;
using webApp_Books.Models;

namespace webApp_Books.Repository.SQL
{
    public class BookSQLRepository:IBookRepository
    {
        private readonly EFDBcontext _dbcontext;
        public BookSQLRepository(EFDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbcontext.Books.ToList();
        }

        public IEnumerable<Book> GetWithFilter(string filter)
        {
            filter = filter.ToLower();
            return _dbcontext.Books.Where(s => s.BookName.Contains(filter) || s.Writer.Contains(filter));
        }

        public Book? GetSingle(int id)
        {
            return _dbcontext.Books.FirstOrDefault(s => s.BookID == id);
        }

        public void Delete(int id)
        {
            var book = _dbcontext.Books.FirstOrDefault(s => s.BookID == id);
            _dbcontext.Books.Remove(book);
            _dbcontext.SaveChanges();
        }

        public int Save(Book book)
        {
            if (book.BookID == 0)
            {
                _dbcontext.Books.Add(book);
            }
            else
            {
                _dbcontext.Books.Update(book);
            }
            _dbcontext.SaveChanges();

            return book.BookID;
        }
    }
}
