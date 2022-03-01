using BooksAPIRest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Repository.Interface
{
    public interface IAuthorRepository
    {
        Task<bool> CreateAuthor(AuthorDTO author);
        Task<IEnumerable<AuthorDTO>> GetAll();
    }
}
