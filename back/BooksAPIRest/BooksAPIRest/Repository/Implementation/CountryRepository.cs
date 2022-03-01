using BooksAPIRest.Models;
using BooksAPIRest.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPIRest.Repository.Implementation
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DatabaseContext databaseContext;

        public CountryRepository()
        {
            databaseContext = new DatabaseContext();
        }

        public CountryRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        async Task<IEnumerable<Country>> ICountryRepository.GetAll()
        {
            try
            {
                return await (from country in databaseContext.Countries orderby country.CountryId select country).ToListAsync();
            }
            catch (Exception)
            {

                return new List<Country>();
            }
        }
    }
}
