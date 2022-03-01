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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DatabaseContext databaseContext;

        public AuthorRepository()
        {
            databaseContext = new DatabaseContext();
        }

        public async Task<bool> CreateAuthor(AuthorDTO author)
        {
            try
            {
                Author newAuthor = new()
                {
                    AuthorFirstName = author.AuthorFirstName,
                    AuthorSecondName = author.AuthorSecondName,
                    AuthorFirstLastName = author.AuthorFirstLastName,
                    AuthorSecondLastName = author.AuthorSecondLastName,
                    AuthorEmail = author.AuthorEmail,
                    BornDate = author.BornDate,
                    OriginCity = author.OriginCity
                };

                databaseContext.Add(newAuthor);
                await databaseContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<AuthorDTO>> GetAll()
        {
            try
            {
                IEnumerable<Author> authors = await (from author in databaseContext.Authors
                                                     orderby author.AuthorId descending
                                                     select author).ToListAsync();

                if (authors != null && authors.Any())
                {
                    List<AuthorDTO> authorResponse = new();

                    foreach (Author author in authors)
                    {
                        AuthorDTO authorDTO = new()
                        {
                            AuthorFirstName = author.AuthorFirstName,
                            AuthorSecondName = author.AuthorSecondName,
                            AuthorFirstLastName = author.AuthorFirstLastName,
                            AuthorSecondLastName = author.AuthorSecondLastName,
                            AuthorEmail = author.AuthorEmail,
                            BornDate = author.BornDate,
                            OriginCity = author.OriginCity,
                        };

                        authorResponse.Add(authorDTO);
                    }

                    return authorResponse;
                }

                return Enumerable.Empty<AuthorDTO>();
            }
            catch (Exception)
            {

                return Enumerable.Empty<AuthorDTO>();
            }
        }
    }
}
