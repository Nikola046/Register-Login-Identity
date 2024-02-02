using webApp_Books.Data;
using webApp_Books.Models;

namespace webApp_Books.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetWithFilter(string filter);
        Book? GetSingle(int id);
        int Save(Book book);
        void Delete(int id);
    }
}
