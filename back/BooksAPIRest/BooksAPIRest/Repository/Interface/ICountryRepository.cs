using BooksAPIRest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Repository.Interface
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAll();
    }
}
