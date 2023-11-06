using EasyCRUDApp.Models;
using EasyCRUDApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EasyCRUDApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public void Post(string title, string description, int year, int pages, int authorId)
        {
            _bookRepository.AddBook(title, description, year, pages, authorId);
        }

        [HttpPut("{id}")]
        public void Put(int id, string title, string description, int year, int pages, int authorId)
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
