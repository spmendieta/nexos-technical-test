using System.Runtime.Serialization;

namespace BooksAPIRest.DTO
{
    [DataContract]
    public class CityDTO
    {
        [DataMember]
        public int CityId { get; set; }

        [DataMember]
        public string CityName { get; set; }
    }
}
