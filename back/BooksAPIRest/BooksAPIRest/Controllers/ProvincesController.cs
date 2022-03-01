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
    public class ProvincesController : ControllerBase
    {
        private readonly IProvinceRepository provinceRepository;

        public ProvincesController()
        {
            provinceRepository = new ProvinceRepository();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProvinceDTO>>> Get(int countryId)
        {
            return Ok(await provinceRepository.GetByCountryId(countryId));
        }
    }
}
