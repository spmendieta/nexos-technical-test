using BooksAPIRest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Repository.Interface
{
    public interface ICityRepository
    {
        Task<IEnumerable<CityDTO>> GetByProvinceId(int provinceId);
    }
}
