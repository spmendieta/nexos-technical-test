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
    public class GenreRepository : IGenreRepository
    {
        private readonly DatabaseContext databaseContext;

        public GenreRepository()
        {
            databaseContext = new DatabaseContext();
        }

        public async Task<IEnumerable<GenreDTO>> GetAll()
        {
            try
            {
                IEnumerable<Genre> genres = await (from genre in databaseContext.Genres
                                                   orderby genre.GenreId descending
                                                   select genre).ToListAsync();
                if (genres != null && genres.Any())
                {
                    List<GenreDTO> genresResponse = new();

                    foreach (Genre genre in genres)
                    {
                        GenreDTO genreResponse = new()
                        {
                            GenreId = genre.GenreId,
                            GenreName = genre.GenreName,
                        };

                        genresResponse.Add(genreResponse);
                    }

                    return genresResponse;
                }

                return Enumerable.Empty<GenreDTO>();
            }
            catch (Exception)
            {

                return Enumerable.Empty<GenreDTO>();
            }
        }
    }
}
