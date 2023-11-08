using EasyCRUDApp.Models;
using EasyCRUDApp.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EasyCRUDApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Angular App")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public List<AuthorDTO> Get()
        {
            return _authorRepository.GetAll();
        }

        [HttpGet("{id}")]
        public AuthorDTO Get(int id)
        {
            return _authorRepository.GetById(id);
        }

        [HttpPost]
        public void Post([FromQuery] string name, [FromQuery] string surname)
        {
            _authorRepository.AddAuthor(name, surname);
        }

        [HttpPut("{id}")]
        public void Put([FromQuery] int id, [FromQuery] string name, [FromQuery] string surname)
        {
            ;
            _authorRepository.UpdateAuthor(id, name, surname);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _authorRepository.DeleteAuthor(id);
        }
    }
}
