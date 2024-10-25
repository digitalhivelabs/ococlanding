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
    public class ItemRepository : CommonRepository<Item>, IItemRepository
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public ItemRepository(DataContex context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Item GetByName(string NameOrAbbr)
        {
            return  _context.Items.SingleOrDefault(x => 
                x.Name.ToLower() == NameOrAbbr.ToLower() 
                || x.Abbr.ToLower() == NameOrAbbr.ToLower() );
        }

        public async Task<IEnumerable<ItemDTO>> GetItemByCategoryAsync(int categoryId)
        {
            return await _context.Items
                .Where(x => x.CategoryId == categoryId)                
                .ProjectTo<ItemDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        
        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            return await _context.Items      
                .ProjectTo<ItemDTO>(_mapper.ConfigurationProvider)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();
        }
    }
}