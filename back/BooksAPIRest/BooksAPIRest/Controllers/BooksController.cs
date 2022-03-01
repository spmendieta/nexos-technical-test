using BooksAPIRest.DTO;
using BooksAPIRest.Repository.Implementation;
using BooksAPIRest.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BooksAPIRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private readonly IBooksRepository booksRepository;

        public BooksController()
        {
            booksRepository = new BooksRepository();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Get()
        {

            return Ok(await booksRepository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<Dictionary<string, object>>> Create([FromBody] BookDTO book)
        {

            return Ok(await booksRepository.CreateBook(book));
        }
    }
}
