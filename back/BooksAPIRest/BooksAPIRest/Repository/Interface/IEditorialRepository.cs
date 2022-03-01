using BooksAPIRest.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Repository.Interface
{
    public interface IEditorialRepository
    {
        Task<IEnumerable<EditorialDTO>> GetAll();
        Task<bool> CreateEditorial(EditorialDTO editorial);
        Task UpdateMaxRegistrationLimit(int editorialId);
    }
}
