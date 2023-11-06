using System.ComponentModel.DataAnnotations;

namespace EasyCRUDApp.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public ICollection<Book> Books { get; set; }


    }
}
