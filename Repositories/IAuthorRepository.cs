using EasyCRUDApp.Models;

namespace EasyCRUDApp.Repositories
{
    public interface IAuthorRepository
    {
        public List<AuthorDTO> GetAll();
        public AuthorDTO GetById(int id);
        public void AddAuthor(string name, string surname);
        public void UpdateAuthor(int id, string name, string surname);
        public void DeleteAuthor(int id);
        public Author FindById(int id);
    }
}
