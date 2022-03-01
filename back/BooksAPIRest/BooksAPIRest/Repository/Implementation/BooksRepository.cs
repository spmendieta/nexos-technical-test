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
    public class BooksRepository : IBooksRepository
    {
        private readonly DatabaseContext databaseContext;
        private readonly IEditorialRepository editorialRepository;

        public BooksRepository()
        {
            databaseContext = new DatabaseContext();
            editorialRepository = new EditorialRepository();
        }

        public async Task<Dictionary<string, object>> CreateBook(BookDTO book)
        {
            Dictionary<string, object> result = new();

            try
            {
                bool editorialExists = databaseContext.Editorials.Any(editorial => editorial.EditorialId == book.EditorialId);

                if (!editorialExists)
                {
                    result.Add("Status", "Fail");
                    result.Add("Detail", "La editorial no está registrada");

                    return result;
                }

                bool authorExists = databaseContext.Authors.Any(author => author.AuthorId == book.AuthorId);

                if (!authorExists)
                {
                    result.Add("Status", "Fail");
                    result.Add("Detail", "El autor no está registrado");

                    return result;
                }

                int editorialCurrentMaxBooksQuantity = (from editorial in databaseContext.Editorials
                                                        where editorial.EditorialId == book.EditorialId
                                                        select editorial.BookRegistrationLimit).FirstOrDefault();



                if (editorialCurrentMaxBooksQuantity != -1)
                {
                    if (editorialCurrentMaxBooksQuantity < 1)
                    {
                        result.Add("Status", "Fail");
                        result.Add("Detail", "No es posible registrar el libro, se alcanzó el máximo permitido.");

                        return result;
                    }
                }

                Book newBook = new()
                {
                    Title = book.Title,
                    Year = book.Year,
                    GenreId = book.GenreId,
                    NumberOfPages = book.NumberOfPages,
                    EditorialId = book.EditorialId,
                    AuthorId = book.AuthorId
                };

                databaseContext.Add(newBook);
                await databaseContext.SaveChangesAsync();

                // Actualziación del limite de registro de libros en la librería en la cuál fue registrado. Se resta una unidad
                await editorialRepository.UpdateMaxRegistrationLimit(newBook.EditorialId);

                result.Add("Status", "Ok");
                result.Add("Detail", "El recurso fue registrado exitosamente");

                return result;
            }
            catch (Exception)
            {
                result.Add("Status", "Fail");
                result.Add("Detail", "Ocurrió un error en el proceso de registro del recurso.");

                return result;
            }
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            try
            {
                var books = await (from book in databaseContext.Books
                                   join editorial in databaseContext.Editorials on book.EditorialId equals editorial.EditorialId
                                   join author in databaseContext.Authors on book.AuthorId equals author.AuthorId
                                   join genre in databaseContext.Genres on book.GenreId equals genre.GenreId
                                   orderby book.BookId descending
                                   select new
                                   {
                                       book.BookId,
                                       book.Title,
                                       book.NumberOfPages,
                                       book.Year,
                                       book.EditorialId,
                                       editorial.EditorialName,
                                       book.AuthorId,
                                       author.AuthorFirstName,
                                       author.AuthorFirstLastName,
                                       genre.GenreName
                                   }).ToListAsync();

                if (books != null && books.Any())
                {
                    List<BookDTO> booksResponse = new();

                    foreach (var book in books)
                    {
                        BookDTO responseBook = new()
                        {
                            BookId = book.BookId,
                            Title = book.Title,
                            NumberOfPages = book.NumberOfPages,
                            Year = book.Year,
                            EditorialId = book.EditorialId,
                            EditorialName = book.EditorialName,
                            AuthorId = book.AuthorId,
                            AuthorName = $"{book.AuthorFirstName} {book.AuthorFirstLastName}",
                            GenreName = book.GenreName
                        };

                        booksResponse.Add(responseBook);
                    }

                    return booksResponse;
                }

                return Enumerable.Empty<BookDTO>();
            }
            catch (Exception)
            {

                return Enumerable.Empty<BookDTO>();
            }
        }
    }
}
