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
using Semaphore = API.Entities.Semaphore;

namespace API.Data
{
    public class QualityStandardRepository : CommonRepository<QualityStandard>, IQualityStandardRepository
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public QualityStandardRepository(DataContex context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QualityStandardODTO>> GetAsync()
        {
            return await _context.QualityStandards
                .ProjectTo<QualityStandardODTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<IEnumerable<QualityStandardO2DTO>> GetDetails(int Id)
        {
            return await _context.QualityStandards
                .Where(x => x.QSId == Id)
                .ProjectTo<QualityStandardO2DTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public QualityStandardItem GetItem(int Id)
        {
            return _context.QualityStandardItems
                .Include(t => t.QualityStandardItemRanges)
                .FirstOrDefault(i => i.QSIId == Id);
        }
        public void AddItem(QualityStandardItem item)
        {
            _context.Entry(item).State = EntityState.Added;
        }
        public void AddItemsRange(IEnumerable<QualityStandardItem> entities)
        {
            _context.Set<QualityStandardItem>().AddRange(entities);
        }
        public void UpdateItem(QualityStandardItem item)
        {
            _context.Set<QualityStandardItem>().Entry(item).State = EntityState.Modified;
        }

        public void DeleteItem(QualityStandardItem item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }
        
        public void DeleteItemRangeRange(IEnumerable<QualityStandardItemRange> entities)
        {
            _context.Set<QualityStandardItemRange>().RemoveRange(entities);
        }


//---
        public void AddItemRange(QualityStandardItemRange item)
        {
            _context.Entry(item).State = EntityState.Added;
        }

        public void AddItemRangesRange(IEnumerable<QualityStandardItemRange> entities)
        {
            _context.Set<QualityStandardItemRange>().AddRange(entities);
        }

        public QualityStandardItemRange GetItemRange(int Id)
        {
            return _context.QualityStandardItemRanges.Find(Id);
        }

        public void UpdateItemRange(QualityStandardItemRange item)
        {
            _context.Set<QualityStandardItemRange>().Entry(item).State = EntityState.Modified;
        }

        public void DeleteItemRange(QualityStandardItemRange item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }
// --
        public void AddItemRangesRangeSemaphore(Semaphore entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }


    }
}