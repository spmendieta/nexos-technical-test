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
    public class CitysController : Controller
    {
        private readonly ICityRepository cityRepository;

        public CitysController()
        {
            cityRepository = new CityRepository();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDTO>>> Get(int provinceId)
        {
            return Ok(await cityRepository.GetByProvinceId(provinceId));
        }
    }
}
