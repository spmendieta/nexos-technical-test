using BooksAPIRest.DTO;
using BooksAPIRest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Repository.Interface
{
    public interface IBooksRepository
    {
        Task<Dictionary<string, object>> CreateBook(BookDTO book);
        Task<IEnumerable<BookDTO>> GetAll();
    }
}
