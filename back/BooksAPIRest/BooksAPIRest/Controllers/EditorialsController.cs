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
    public class EditorialsController : Controller
    {
        private readonly IEditorialRepository editorialRepository;
        public EditorialsController()
        {
            editorialRepository = new EditorialRepository();
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] EditorialDTO editorial)
        {
            bool result = await editorialRepository.CreateEditorial(editorial);

            return result ? Ok(result) : NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditorialDTO>>> Get()
        {
            return Ok(await editorialRepository.GetAll());
        }
    }
}
