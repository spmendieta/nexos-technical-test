using System;
using System.Collections.Generic;

#nullable disable

namespace BooksAPIRest.Models
{
    public partial class Author
    {
        public int AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorSecondName { get; set; }
        public string AuthorFirstLastName { get; set; }
        public string AuthorSecondLastName { get; set; }
        public string AuthorEmail { get; set; }
        public int OriginCity { get; set; }
        public DateTime BornDate { get; set; }
    }
}
