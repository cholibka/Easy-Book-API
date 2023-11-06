using EasyCRUDApp.Models;

namespace EasyCRUDApp.Repositories
{
    public interface IBookRepository
    {
        public List<BookDTO> GetAll();
        public BookDTO GetById(int id);
        public List<BookDTO> GetByAuthorId(int ud);
        public void AddBook(string title, string description, int year, int pages, int authorId);
        public void UpdateBook(int id, string title, string description, int year, int pages, int authorId);
        public void DeleteBook(int id);
    }
}
