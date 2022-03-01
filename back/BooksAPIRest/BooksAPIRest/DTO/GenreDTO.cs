using System.Runtime.Serialization;

namespace BooksAPIRest.DTO
{
    [DataContract]
    public class GenreDTO
    {
        [DataMember]
        public int GenreId { get; set; }

        [DataMember]
        public string GenreName { get; set; }
    }
}
