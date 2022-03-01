using System.Runtime.Serialization;

namespace BooksAPIRest.DTO
{
    [DataContract]
    public class EditorialDTO
    {
        [DataMember]
        public int EditorialId { get; set; }

        [DataMember]
        public string EditorialName { get; set; }

        [DataMember]
        public string CorrespondanceAdress { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public int BookRegistrationLimit { get; set; }

        [DataMember]
        public int CityId { get; set; }
    }
}
