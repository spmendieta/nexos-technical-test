using BooksAPIRest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Repository.Interface
{
    public interface IGenreRepository
    {
        Task<IEnumerable<GenreDTO>> GetAll();
    }
}
