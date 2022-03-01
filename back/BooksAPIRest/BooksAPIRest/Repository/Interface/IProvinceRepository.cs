using BooksAPIRest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Repository.Interface
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<ProvinceDTO>> GetByCountryId(int countryId);
    }
}
