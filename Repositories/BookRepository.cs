using EasyCRUDApp.Db;
using EasyCRUDApp.Models;

namespace EasyCRUDApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        private readonly IAuthorRepository _authorRepository;
        public BookRepository(DataContext context, IAuthorRepository authorRepository)
        {
            _context = context;
            _authorRepository = authorRepository;
        }

        public void AddBook(string title, string description, int year, int pages, int authorId)
        {
            Book newBook = new()
            {
                Title = title,
                Description = description,
                ReleaseYear = year,
                NumberOfPages = pages,
                AuthorId = authorId
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book book = FindById(id);
            _context.Remove(book);
            _context.SaveChanges();
        }

        public List<BookDTO> GetAll()
        {
            return _context.Books.Select(x => new BookDTO()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ReleaseYear = x.ReleaseYear,
                NumberOfPages = x.NumberOfPages,
                AuthorName = $"{x.Author.Name} {x.Author.Surname}"
            }).ToList();
        }

        public List<BookDTO> GetByAuthorId(int id)
        {
            return _context.Books.Where(x => x.Author.Id == id).Select(x => new BookDTO()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ReleaseYear = x.ReleaseYear,
                NumberOfPages = x.NumberOfPages,
                AuthorName = $"{x.Author.Name} {x.Author.Surname}"
            }).ToList() ?? throw new ArgumentNullException($"Couldn't find author with id: {id}");
        }

        public BookDTO GetById(int id)
        {
            return _context.Books.Select(x => x).Where(x => x.Id == id).Select(x => new BookDTO()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ReleaseYear = x.ReleaseYear,
                NumberOfPages = x.NumberOfPages,
                AuthorName = $"{x.Author.Name} {x.Author.Surname}"
            }).FirstOrDefault() ?? throw new ArgumentNullException($"Couldn't find book with id: {id}");
        }

        public void UpdateBook(int id, string title, string description, int year, int pages, int authorId)
        {
            Book book = FindById(id);
            _authorRepository.FindById(authorId);
            book.Title = title;
            book.Description = description;
            book.ReleaseYear = year;
            book.NumberOfPages = pages;
            book.AuthorId = authorId;

            _context.SaveChanges();
        }

        private Book FindById(int id)
        {
            return _context.Books.Where(x => x.Id == id).FirstOrDefault() ?? throw new ArgumentNullException($"Couldn't find book with id: {id}");
        }
    }
}
