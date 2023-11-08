using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyCRUDApp.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public int NumberOfPages { get; set; }
        [ForeignKey(nameof(Author))]
        public int? AuthorId { get; set; }


        public Author? Author { get; set; }
    }
}
