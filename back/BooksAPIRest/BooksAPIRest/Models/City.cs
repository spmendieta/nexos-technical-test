using System;
using System.Collections.Generic;

#nullable disable

namespace BooksAPIRest.Models
{
    public partial class City
    {
        public City()
        {
            Editorials = new HashSet<Editorial>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<Editorial> Editorials { get; set; }
    }
}
