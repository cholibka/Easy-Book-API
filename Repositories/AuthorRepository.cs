using EasyCRUDApp.Db;
using EasyCRUDApp.Models;

namespace EasyCRUDApp.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public void AddAuthor(string name, string surname)
        {
            Author newAuthor = new()
            {
                Name = name,
                Surname = surname
            };

            _context.Authors.Add(newAuthor);
            _context.SaveChanges();

        }

        public void DeleteAuthor(int id)
        {
            Author author = FindById(id);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public List<AuthorDTO> GetAll()
        {
            return _context.Authors.Select(x => new AuthorDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                BooksTitle = x.Books.Select(x => x.Title).ToList()

            }).ToList();
        }

        public AuthorDTO GetById(int id)
        {
            return _context.Authors.Where(x => x.Id == id).Select(x => new AuthorDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                BooksTitle = x.Books.Select(x => x.Title).ToList()

            }).FirstOrDefault() ?? throw new ArgumentNullException($"Couldn't find author with id: {id}");
        }

        public void UpdateAuthor(int id, string name, string surname)
        {
            Author author = FindById(id);
            author.Name = name;
            author.Surname = surname;
            _context.SaveChanges();
        }

        public Author FindById(int id)
        {
            return _context.Authors.Where(x => x.Id == id).FirstOrDefault() ?? throw new ArgumentNullException($"Couldn't find author with id: {id}");
        }
    }
}
