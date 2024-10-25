using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.StoreProcedureReturn;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CategoryRepository : CommonRepository<Category>, ICategoryRepository
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DataContex context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubCategoryODTO>> GetPlaces(int categoryId, int stateId, string UMed)
        {  // Todo: Cambiar por SP
            var tSQL = "EXEC dbo.GetSubCategoriesAndPoints @SubCatId, @StateId, @Lat, @Lon, @UMed";
            var pLat = new SqlParameter("Lat",SqlDbType.Float,7);
            pLat.Value = 0.0;
            var pLon = new SqlParameter("Lon",SqlDbType.Float,7);
            pLon.Value = 0.0;
            var parm = new List<SqlParameter>()
            {
                new SqlParameter("SubCatId", categoryId),
                new SqlParameter("StateId", stateId),
                pLat,
                pLon,
                new SqlParameter("UMed", UMed)
            };

            // var SC = await _context.GetSubCategoriesAndPoints.FromSqlRaw<GetSubCategoriesAndPointsSPR>(tSQL,parm.ToArray()).ToListAsync();
            var SC = await _context.SP_SubCategoriesAndPoints.FromSqlRaw<GetSubCategoriesAndPointsSPR>(tSQL,parm.ToArray()).ToListAsync();
            var r = new List<SubCategoryODTO>();
            int scId = 0;
            var scT = new SubCategoryODTO();

            foreach(var s in SC) {
                if (scId != s.id) {
                    scId = s.id;
                    scT =new SubCategoryODTO() {SubCategoryId = s.id, DisplayName = s.name, Places = new List<PlaceODTO>()};
                    r.Add(scT);
                }

                scT.Places.Add(new PlaceODTO()
                    { PlaceID = s.PlaceId, DisplayName = s.DisplayName
                    , URLImage = s.URLImage, Distance = s.Distance, NumPoints = s.NumPoints});

            }

            /*
            return await _context.SubCategories
                .Include(s => s.Places.Where(p => p.StateId == stateId))
                .Where(x => x.CategoryId == categoryId)
                .ProjectTo<SubCategoryODTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            */

            return r;
        }

        public async Task<IEnumerable<SubCategoryODTO>> GetPlacesLatLon(int categoryId, float lat, float lon, string uMed)
        {  // Todo: Cambiar por SP
            var tSQL = "EXEC dbo.GetSubCategoriesAndPoints @SubCatId, @StateId, @Lat, @Lon, @UMed";
            var pLat = new SqlParameter("Lat",SqlDbType.Float,7);
            pLat.Value = lat;
            var pLon = new SqlParameter("Lon",SqlDbType.Float,7);
            pLon.Value = lon;
            var pStateId = new SqlParameter("StateId",SqlDbType.Int);
            pStateId.Value = 0;
            var parm = new List<SqlParameter>()
            {
                new SqlParameter("SubCatId", categoryId),
                pStateId,
                pLat,
                pLon,
                new SqlParameter("UMed", uMed)
            };

            // var SC = await _context.GetSubCategoriesAndPoints.FromSqlRaw<GetSubCategoriesAndPointsSPR>(tSQL,parm.ToArray()).ToListAsync();
            var SC = await _context.SP_SubCategoriesAndPoints.FromSqlRaw<GetSubCategoriesAndPointsSPR>(tSQL,parm.ToArray()).ToListAsync();
            var r = new List<SubCategoryODTO>();
            int scId = 0;
            var scT = new SubCategoryODTO();

            foreach(var s in SC) {
                if (scId != s.id) {
                    scId = s.id;
                    scT =new SubCategoryODTO() {SubCategoryId = s.id, DisplayName = s.name, Places = new List<PlaceODTO>()};
                    r.Add(scT);
                }

                scT.Places.Add(new PlaceODTO()
                    { PlaceID = s.PlaceId, DisplayName = s.DisplayName
                    , URLImage = s.URLImage, Distance = s.Distance + ' ' + uMed, NumPoints = s.NumPoints});

            }

            /*
            return await _context.SubCategories
                .Include(s => s.Places)
                .Where(x => x.CategoryId == categoryId)
                .ProjectTo<SubCategoryODTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            */

            return r;
        }

        public async Task<IEnumerable<SubCategoryDTO>> GetSubCategory(int categoryId)
        {
            return await _context.SubCategories                
                .Where(x => x.CategoryId == categoryId)
                .ProjectTo<SubCategoryDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}