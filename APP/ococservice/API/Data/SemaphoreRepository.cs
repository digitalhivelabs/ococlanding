using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;
using Semaphore = API.Entities.Semaphore;

namespace API.Data
{
    public class SemaphoreRepository : CommonRepository<Semaphore>, ISemaphoreRepository
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public SemaphoreRepository(DataContex context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Semaphore GetByName(string NameOrAbbr)
        {
             return _context.Semaphores.SingleOrDefault(x => 
                x.Name.ToLower() == NameOrAbbr.ToLower() 
                || x.Color.ToLower() == NameOrAbbr.ToLower() );
        }
    }
}