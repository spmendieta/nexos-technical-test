using BooksAPIRest.DTO;
using BooksAPIRest.Models;
using BooksAPIRest.Repository.Interface;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPIRest.Repository.Implementation
{
    public class CityRepository : ICityRepository
    {
        private readonly DatabaseContext databaseContext;

        public CityRepository()
        {
            databaseContext = new DatabaseContext();
        }

        public async Task<IEnumerable<CityDTO>> GetByProvinceId(int provinceId)
        {
            try
            {
                IEnumerable<City> cities = await (from city in databaseContext.Cities
                                                  where city.ProvinceId == provinceId
                                                  orderby city.CityId descending
                                                  select city).ToListAsync();

                if (cities != null && cities.Any())
                {
                    List<CityDTO> citiesResponse = new();

                    foreach (City city in cities)
                    {
                        CityDTO cityResponse = new()
                        {
                            CityId = city.CityId,
                            CityName = city.CityName,
                        };

                        citiesResponse.Add(cityResponse);
                    }

                    return citiesResponse;
                }

                return new List<CityDTO>();
            }
            catch (Exception)
            {

                return new List<CityDTO>();
            }
        }
    }
}
