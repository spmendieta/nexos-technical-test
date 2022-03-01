using System;
using System.Collections.Generic;

#nullable disable

namespace BooksAPIRest.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public int GenreId { get; set; }
        public short NumberOfPages { get; set; }
        public int EditorialId { get; set; }
        public int AuthorId { get; set; }

        public virtual Editorial Editorial { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
