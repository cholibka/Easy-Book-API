namespace EasyCRUDApp.Models
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public List<string> BooksTitle { get; set; } = new List<string>();
    }
}
