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
    public class PointRepository : CommonRepository<Point>, IPointRepository
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public PointRepository(DataContex context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PointDTO>> GetPointByPlace(int placeId)
        {
            return await _context.Points
                .Where(x => x.PlaceId == placeId)
                .ProjectTo<PointDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}