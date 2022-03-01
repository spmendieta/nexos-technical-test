using System;
using System.Runtime.Serialization;

namespace BooksAPIRest.DTO
{
    [DataContract]
    public class BookDTO
    {
        [DataMember]
        public int BookId { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime Year { get; set; }

        [DataMember]
        public int GenreId { get; set; }

        [DataMember]
        public string GenreName { get; set; }

        [DataMember]
        public short NumberOfPages { get; set; }

        [DataMember]
        public int EditorialId { get; set; }

        [DataMember]
        public string EditorialName { get; set; }

        [DataMember]
        public int AuthorId { get; set; }

        [DataMember]
        public string AuthorName { get; set; }
    }
}
