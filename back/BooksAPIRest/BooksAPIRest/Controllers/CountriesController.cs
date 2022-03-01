using BooksAPIRest.Models;
using BooksAPIRest.Repository.Implementation;
using BooksAPIRest.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;

        public CountriesController()
        {
            countryRepository = new CountryRepository();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
        {

            return Ok(await countryRepository.GetAll());
        }
    }
}
