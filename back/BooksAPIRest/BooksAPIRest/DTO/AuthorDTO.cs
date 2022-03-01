using System;
using System.Runtime.Serialization;

namespace BooksAPIRest.DTO
{
    [DataContract]
    public class AuthorDTO
    {
        [DataMember]
        public string AuthorFirstName { get; set; }
        public string AuthorSecondName { get; set; }
        public string AuthorFirstLastName { get; set; }
        public string AuthorSecondLastName { get; set; }
        public string AuthorEmail { get; set; }
        public int OriginCity { get; set; }
        public DateTime BornDate { get; set; }
    }
}
