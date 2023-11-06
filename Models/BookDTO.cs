namespace EasyCRUDApp.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int NumberOfPages { get; set; }
        public string AuthorName { get; set; } = string.Empty;
    }
}
