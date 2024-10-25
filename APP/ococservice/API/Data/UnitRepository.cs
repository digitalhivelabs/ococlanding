using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitRepository : CommonRepository<Unit>, IUnitRepository
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public UnitRepository(DataContex context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Unit GetByName(string NameOrAbbr)
        {
            return _context.Units.SingleOrDefault(x => 
                x.Name.ToLower() == NameOrAbbr.ToLower() 
                || x.Abbr.ToLower() == NameOrAbbr.ToLower() );
        }
    }
}