using Microsoft.AspNetCore.Mvc;
using BooksAPIRest.DTO;
using BooksAPIRest.Repository.Implementation;
using BooksAPIRest.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorsController()
        {
            authorRepository = new AuthorRepository();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] AuthorDTO author)
        {
            bool result = await authorRepository.CreateAuthor(author);

            return result ? Ok(result) : NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> Get()
        {
            return Ok(await authorRepository.GetAll());
        }
    }
}
