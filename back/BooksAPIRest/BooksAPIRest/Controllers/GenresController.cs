using BooksAPIRest.DTO;
using BooksAPIRest.Repository.Implementation;
using BooksAPIRest.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController : Controller
    {
        private readonly IGenreRepository booksRepository;

        public GenresController()
        {
            booksRepository = new GenreRepository();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> Get()
        {

            return Ok(await booksRepository.GetAll());
        }
    }
}
