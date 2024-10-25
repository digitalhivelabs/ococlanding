using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using API.StoreProcedureReturn;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json.Linq;


namespace API.Data
{
    public class SpesimenRepository :  CommonRepository<Spesimen>, ISpesimenRepository
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public SpesimenRepository(DataContex context, IMapper mapper): base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // public void Add(Survey survey)
        // {
        //     _context.Entry(survey).State = EntityState.Added;
        // }

        public void AddItem(SpesimenItem item)
        {
            _context.Entry(item).State = EntityState.Added;
        }

        public void AddItemsRange(IEnumerable<SpesimenItem> entities)
        {
            _context.Set<SpesimenItem>().AddRange(entities);
        }

        public async Task<IEnumerable<SpesimenDTO>> GetAsync()
        {
            return await _context.Spesimens
                .ProjectTo<SpesimenDTO>(_mapper.ConfigurationProvider)
                .OrderBy(s => s.CDate).ToListAsync();
        }

        public async Task<IEnumerable<SpesimenDashboardDTO>> GetSpesimenDashboard()
        {
            var sdDTO = await _context.SpesimenItems
                .ProjectTo<SpesimenDashboardDTO>(_mapper.ConfigurationProvider)
                .OrderBy(s => s.Parameter).ThenBy(s => s.Point).ThenBy(s => s.Laboratory).ThenBy(s => s.SpecimenDate)
                //.OrderBy(s => s.SpecimenDate).ThenBy(s => s.Point).ThenBy(s => s.Laboratory).ThenBy(s => s.Parameter)
                .ToListAsync();

                //return sdDTO;
            

            var prmCom = ""; // Parameter + Point + Laboratory
            var v = 0f;
            
            
            foreach(var s in sdDTO) {
                if (prmCom == "") {
                    prmCom = s.Parameter + s.Point + s.Laboratory;
                    s.Tendency = "";
                    s.TendencyIcon = "";
                    v = s.value;
                    s.SpecimenDate = s.SpecimenDate.Substring(0,10);
                    continue;
                }

                if (prmCom == s.Parameter + s.Point + s.Laboratory) {
                    if (v > s.value) {
                        s.Tendency = (s.value - v).ToString();
                        s.TendencyIcon = "D";
                    } 
                    if (v < s.value) {
                        s.Tendency = (s.value - v).ToString();
                        s.TendencyIcon = "U";
                    } 

                    v = s.value;

                    if (s.Tendency == null) {
                        s.Tendency = "";
                        s.TendencyIcon = "";
                    }

                } else {
                    prmCom = s.Parameter + s.Point + s.Laboratory;
                    s.Tendency = "";
                    s.TendencyIcon = "";
                    v = s.value;
                }

                s.SpecimenDate = s.SpecimenDate.Substring(0,10);

            }

            //sdDTO.OrderByDescending(s => s.SpecimenDate);

            return sdDTO.OrderByDescending(s => s.SpecimenDate);
            
        }

        public async Task<SpesimenDTO> GetSpesimenDTOByIdAsync(int id)
        {
            return await _context.Spesimens
                .Where(s => s.SpesimenId == id)
                .ProjectTo<SpesimenDTO>(_mapper.ConfigurationProvider)
                .OrderBy(s => s.CDate)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<SpesimensInPointDTO>> SpesimensInPoint(int pointId, DateTime dateC, int categoryId, int qsId)
        {
            var tSQL = "EXEC dbo.GetSpesimensByPointId @PointId, @DateC, @CategoryId, @QSId";
             
            var pDateC = new SqlParameter("DateC",SqlDbType.DateTime);
            pDateC.Value = dateC;

            var parm = new List<SqlParameter>()
            {
                new SqlParameter("PointId", pointId),
                pDateC,
                new SqlParameter("CategoryId", categoryId),
                new SqlParameter("QSId", qsId)
            };

            // var SC = await _context.GetSubCategoriesAndPoints.FromSqlRaw<GetSubCategoriesAndPointsSPR>(tSQL,parm.ToArray()).ToListAsync();
            var SC = await _context.SP_SpesimensByPointIdSPR.FromSqlRaw<GetSpesimensByPointIdSPR>(tSQL,parm.ToArray()).ToListAsync();
            var r = new List<SpesimensInPointDTO>();
            // int scId = 0;
            var r0 = new SpesimensInPointDTO();

            foreach(var s in SC) {
                r0 =new SpesimensInPointDTO() {
                    LabName = s.LabName,
                    Method = s.Method,
                    ItemName = s.ItemName,
                    UnitName = s.UnitName,
                    Value = s.Value,
                    UnitAbbr = s.UnitAbbr,
                    QS_Notes = s.QS_Notes,
                    QS_Name = s.QS_Name,
                    QS_Color = s.QS_Color,
                    QS_Hex = s.QS_Hex
                    };
                r.Add(r0);
                                
            }

            return r;
        }

        // public async Task<bool> SaveAllAsync()
        // {
        //     return await _context.SaveChangesAsync() > 0;
        // }

        // public void Update(Survey survey)
        // {
        //     _context.Entry(survey).State = EntityState.Modified;
        // }

        public void UpdateItem(SpesimenItem item)
        {
            _context.Set<SpesimenItem>().Entry(item).State = EntityState.Modified;
        }
    }
}