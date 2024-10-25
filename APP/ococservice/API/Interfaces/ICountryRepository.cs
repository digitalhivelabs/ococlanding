using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICountryRepository: ICommonRepository<Country>
    {
        Task<IEnumerable<StateDTO>> GetStates(int countryId);
        Task<IEnumerable<PlaceDTO>> GetPlaces(int stateId, int subCategoryId);
    }
}