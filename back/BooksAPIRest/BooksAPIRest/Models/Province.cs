using System;
using System.Collections.Generic;

#nullable disable

namespace BooksAPIRest.Models
{
    public partial class Province
    {
        public Province()
        {
            Cities = new HashSet<City>();
        }

        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
