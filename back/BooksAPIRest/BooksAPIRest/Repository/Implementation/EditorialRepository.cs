using BooksAPIRest.DTO;
using BooksAPIRest.Repository.Interface;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksAPIRest.Models;

namespace BooksAPIRest.Repository.Implementation
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly DatabaseContext databaseContext;

        public EditorialRepository()
        {
            databaseContext = new DatabaseContext();
        }

        public async Task<bool> CreateEditorial(EditorialDTO editorial)
        {
            try
            {
                Editorial newEditorial = new()
                {
                    EditorialName = editorial.EditorialName,
                    CorrespondanceAdress = editorial.CorrespondanceAdress,
                    Phone = editorial.Phone,
                    Email = editorial.Email,
                    CityId = editorial.CityId,
                    BookRegistrationLimit = editorial.BookRegistrationLimit
                };

                databaseContext.Add(newEditorial);
                await databaseContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<EditorialDTO>> GetAll()
        {
            try
            {
                IEnumerable<Editorial> editorials = await (from editorial in databaseContext.Editorials
                                                           orderby editorial.EditorialId descending
                                                           select editorial).ToListAsync();

                if (editorials != null & editorials.Any())
                {
                    List<EditorialDTO> editorialsResponse = new();

                    foreach (Editorial editorial in editorials)
                    {
                        EditorialDTO editorialDTO = new()
                        {
                            EditorialId = editorial.EditorialId,
                            EditorialName = editorial.EditorialName,
                            CorrespondanceAdress = editorial.CorrespondanceAdress,
                            Email = editorial.Email,
                            Phone = editorial.Phone,
                            BookRegistrationLimit = editorial.BookRegistrationLimit
                        };

                        editorialsResponse.Add(editorialDTO);
                    }

                    return editorialsResponse;
                }

                return new List<EditorialDTO>();
            }
            catch (Exception)
            {

                return new List<EditorialDTO>();
            }
        }

        public async Task UpdateMaxRegistrationLimit(int editorialId)
        {
            Editorial editorialToUpdate = (from editorial in databaseContext.Editorials
                                           where editorial.EditorialId == editorialId
                                           select editorial).FirstOrDefault();

            if (editorialToUpdate != null && editorialToUpdate.BookRegistrationLimit != -1)
            {
                if (editorialToUpdate.BookRegistrationLimit > 0)
                    editorialToUpdate.BookRegistrationLimit--;

                await databaseContext.SaveChangesAsync();
            }
        }
    }
}
