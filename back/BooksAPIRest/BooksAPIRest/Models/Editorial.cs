using System;
using System.Collections.Generic;

#nullable disable

namespace BooksAPIRest.Models
{
    public partial class Editorial
    {
        public Editorial()
        {
            Books = new HashSet<Book>();
        }

        public int EditorialId { get; set; }
        public string EditorialName { get; set; }
        public string CorrespondanceAdress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int BookRegistrationLimit { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
