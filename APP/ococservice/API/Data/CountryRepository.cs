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

namespace API.Data
{
    public class CountryRepository : CommonRepository<Country>, ICountryRepository
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public CountryRepository(DataContex context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlaceDTO>> GetPlaces(int stateId, int subCategoryId)
        {
            return await _context.Places
                .Where(x => x.SubCategoryId == subCategoryId && x.StateId == stateId)                
                .ProjectTo<PlaceDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<StateDTO>> GetStates(int countryId)
        { 
            return await _context.States
                .Where(x => x.CountryId == countryId)
                .ProjectTo<StateDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}