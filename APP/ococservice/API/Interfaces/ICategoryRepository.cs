using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface ICategoryRepository: ICommonRepository<Category>
    {
        Task<IEnumerable<SubCategoryODTO>> GetPlacesLatLon(int categoryId, float lat, float lon, string uMed);
        Task<IEnumerable<SubCategoryODTO>> GetPlaces(int categoryId, int stateId, string uMed);
        Task<IEnumerable<SubCategoryDTO>> GetSubCategory(int categoryId);
    }
}