using BooksAPIRest.Models;
using BooksAPIRest.Repository.Interface;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksAPIRest.DTO;

namespace BooksAPIRest.Repository.Implementation
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProvinceRepository()
        {
            databaseContext = new DatabaseContext();
        }

        async Task<IEnumerable<ProvinceDTO>> IProvinceRepository.GetByCountryId(int countryId)
        {
            try
            {
                IEnumerable<Province> provinces = await (from province in databaseContext.Provinces
                                                         where province.CountryId == countryId
                                                         orderby province.ProvinceId
                                                         select province).ToListAsync();

                if (provinces != null && provinces.Any())
                {
                    List<ProvinceDTO> providencesResponse = new();

                    foreach (Province province in provinces)
                    {
                        ProvinceDTO provinceDTO = new()
                        {
                            ProvidenceId = province.ProvinceId,
                            ProvidenceName = province.ProvinceName,
                        };

                        providencesResponse.Add(provinceDTO);
                    }

                    return providencesResponse;
                }

                return new List<ProvinceDTO>();
            }
            catch (Exception)
            {

                return new List<ProvinceDTO>();
            }
        }
    }
}
