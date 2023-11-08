using EasyCRUDApp.Models;
using EasyCRUDApp.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EasyCRUDApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular App")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public List<BookDTO> Get()
        {
            return _bookRepository.GetAll();
        }

        [HttpGet("{id}")]
        public BookDTO Get(int id)
        {
            return _bookRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromQuery] string title, [FromQuery] string description, [FromQuery] int year, [FromQuery] int pages, [FromQuery] int authorId)
        {
            _bookRepository.AddBook(title, description, year, pages, authorId);
        }

        [HttpPut("{id}")]
        public void Put([FromQuery] int id, [FromQuery] string title, [FromQuery] string description, [FromQuery] int year, [FromQuery] int pages, [FromQuery] int authorId)
        {
            _bookRepository.UpdateBook(id, title, description, year, pages, authorId);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bookRepository.DeleteBook(id);
        }
    }
}
