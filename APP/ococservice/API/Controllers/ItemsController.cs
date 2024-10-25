using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ItemsController: BaseApiController
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepositoy _userRepositoy;
        private readonly IMapper _mapper;
        private readonly ILogApi _logApi;

        public ItemsController(IItemRepository itemRepository, IUserRepositoy userRepositoy
            , IMapper mapper, ILogApi logApi)
        {
            _itemRepository = itemRepository;
            _userRepositoy = userRepositoy;
            _mapper = mapper;
            _logApi = logApi;
        }

        [HttpGet()] // "{isActive}"
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems() 
        {
            try
            {

                var it = await _itemRepository.GetItemsAsync();
                //var itR = _mapper.Map<IEnumerable<ItemDTO>>(it);

                return Ok(it);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Items.GetItem", "N/A"); //JsonSerializer.Serialize(survey));
                return StatusCode(500, new MessageResponse());  
            } 
        }

        [HttpGet("{categoryId}")] // "{isActive}"
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItemByCategory(int categoryId) 
        {
            try
            {

                var it = await _itemRepository.GetItemByCategoryAsync(categoryId);
                //var itR = _mapper.Map<IEnumerable<CountryDTO>>(it);

                return Ok(it);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Items.GetItemByCategory", "categoryId: " + categoryId.ToString()); //JsonSerializer.Serialize(survey));
                return StatusCode(500, new MessageResponse());  
            } 
        }        
    }
}