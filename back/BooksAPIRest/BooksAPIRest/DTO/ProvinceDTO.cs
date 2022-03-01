using System.Runtime.Serialization;

namespace BooksAPIRest.DTO
{
    [DataContract]
    public class ProvinceDTO
    {
        [DataMember]
        public int ProvidenceId { get; set; }

        [DataMember]
        public string ProvidenceName { get; set; }
    }
}
