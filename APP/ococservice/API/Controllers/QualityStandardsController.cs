using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Semaphore = API.Entities.Semaphore;

namespace API.Controllers
{
    [Authorize]
    public class QualityStandardsController: BaseApiController
    {
        private readonly IQualityStandardRepository _qualityStandardRepository;
        private readonly IUserRepositoy _userRepositoy;
        private readonly IMapper _mapper;
        private readonly ILogApi _logApi;

        public QualityStandardsController(IQualityStandardRepository qualityStandardRepository, IUserRepositoy userRepositoy
            , IMapper mapper, ILogApi logApi)
        {
            _qualityStandardRepository = qualityStandardRepository;
            _userRepositoy = userRepositoy;
            _mapper = mapper;
            _logApi = logApi;
        }

       [HttpGet()] // "{isActive}"
        public async Task<ActionResult<IEnumerable<QualityStandardODTO>>> GetQualityStandars() 
        {
            try
            {

                var it = await _qualityStandardRepository.GetAllAsync();
                var itR = _mapper.Map<IEnumerable<QualityStandardODTO>>(it);

                return Ok(itR);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.GetQualityStandars", "N/A"); //JsonSerializer.Serialize(survey));
                return StatusCode(500, new MessageResponse());  
            } 
        }     

        [HttpGet("{id}/details")] // "{isActive}"
        public async Task<ActionResult<IEnumerable<QualityStandardO2DTO>>> GetDetails(int id) 
        {
            try
            {

                var it = await _qualityStandardRepository.GetDetails(id);
                //var itR = _mapper.Map<IEnumerable<QualityStandardODTO>>(it);

                return Ok(it);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.GetDetails", "Id: " + id.ToString()); //JsonSerializer.Serialize(survey));
                return StatusCode(500, new MessageResponse());  
            } 
        }     
        
        [HttpPost()] // Post: api/semaphores
        public async Task<ActionResult<bool>> Create(QualityStandardIDTO item) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var it = new QualityStandard();
                
                _mapper.Map(item, it);

                _qualityStandardRepository.Add(it);
                _qualityStandardRepository.AddItemsRange(it.QualityStandardItems);
                foreach(QualityStandardItem r in it.QualityStandardItems){
                    _qualityStandardRepository.AddItemRangesRange(r.QualityStandardItemRanges);
                    // foreach(QualityStandardItemRange r2 in r.QualityStandardItemRanges){
                    //     if (r2.SemaphoreId == null || r2.SemaphoreId == 0 ) {
                    //         _qualityStandardRepository.AddItemRangesRangeSemaphore(r2.Semaphore);
                    //     }
                    // }
                }
                
                await _qualityStandardRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Added", Message = it.QSId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.Create", JsonSerializer.Serialize(item));
                return StatusCode(500,new MessageResponse());            
            }

        }

        [HttpPut("{id}")] // Post: api/semaphores
        public async Task<ActionResult<bool>> Update(QualityStandardUDTO item, int id) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var it = _qualityStandardRepository.GetId(id);

                if (it == null) return BadRequest(new MessageResponse("405","Quality Standard not found"));
                
                _mapper.Map(item, it);

                _qualityStandardRepository.Update(it);

                await _qualityStandardRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Updated", Message = it.QSId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.Update", JsonSerializer.Serialize(item));
                return StatusCode(500,new MessageResponse());            
            }

        }

        // Items
        [HttpPost("{id}/item")] // Post: api/qualityStandards
        public async Task<ActionResult<bool>> AddItem(QualityStandardItemIDTO item, int id) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                //var it = new QualityStandard();
                var sq = _qualityStandardRepository.GetId(id);
                var it = new QualityStandardItem();

                _mapper.Map(item, it);
                it.QSId = id;

                _qualityStandardRepository.AddItem(it);
                _qualityStandardRepository.AddItemRangesRange(it.QualityStandardItemRanges);
                
                
                await _qualityStandardRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Added", Message = it.QSId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.AddItem", "QSId: " + id.ToString() + "; Item: " + JsonSerializer.Serialize(item));
                return StatusCode(500,new MessageResponse());            
            }

        }

        [HttpPut("item/{qsItemId}")] // Post: api/semaphores
        public async Task<ActionResult<bool>> UpdateItem(QualityStandardItemUDTO item, int id, int qsItemId) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var it = _qualityStandardRepository.GetItem(qsItemId);

                if (it == null) return BadRequest(new MessageResponse("405","Quality Standard Item not found"));
                
                //_mapper.Map(item, it);
                it.UnitId = item.UnitId;

                _qualityStandardRepository.UpdateItem(it);

                await _qualityStandardRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Updated", Message = qsItemId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.UpdateItem", JsonSerializer.Serialize(item));
                return StatusCode(500,new MessageResponse());            
            }

        }

        [HttpDelete("item/{qsItemId}")] // Post: api/semaphores
        public async Task<ActionResult<bool>> DeleteItem(int qsItemId) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var it = _qualityStandardRepository.GetItem(qsItemId);

                if (it == null) return BadRequest(new MessageResponse("405","Quality Standard Item not found"));
                
                //_mapper.Map(item, it);
                //it.UnitId = item.UnitId;
                //it.QualityStandardItemRanges.Clear();
                _qualityStandardRepository.DeleteItemRangeRange(it.QualityStandardItemRanges); 

                _qualityStandardRepository.DeleteItem(it);

                await _qualityStandardRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Deleted", Message = qsItemId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.DeleteItem", "QSItemId: " + qsItemId.ToString());
                return StatusCode(500,new MessageResponse());            
            }

        }

        // Items-Ranges
        [HttpPost("{qsItemId}/itemRange")] // Post: api/qualityStandards
        public async Task<ActionResult<bool>> AddItemRange(QualityStandardItemRangeIDTO entityRange, int qsItemId) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var it = _qualityStandardRepository.GetItem(qsItemId); // .GetId(id);
                if (it == null) return BadRequest(new MessageResponse("405","Quality Standard Item not found"));

                var itR = new QualityStandardItemRange();

                _mapper.Map(entityRange, itR);
                itR.QSIId = qsItemId;

                _qualityStandardRepository.AddItemRange(itR);
                it.QualityStandardItemRanges.Add(itR);
                
                await _qualityStandardRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Added", Message = it.QSId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.AddItemRange", "QSItemId: " + qsItemId.ToString() + "; Entity: " + JsonSerializer.Serialize(entityRange));
                return StatusCode(500,new MessageResponse());            
            }

        }

        [HttpPut("itemRange/{qsItemRangeId}")] // Post: api/semaphores
        public async Task<ActionResult<bool>> UpdateItemRange(QualityStandardItemRangeI2DTO entityRange, int qsItemRangeId) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var it = _qualityStandardRepository.GetItemRange(qsItemRangeId);

                if (it == null) return BadRequest(new MessageResponse("405","Quality Standard ItemRange not found"));
                
                _mapper.Map(entityRange, it);
                //it.UnitId = item.UnitId;

                _qualityStandardRepository.UpdateItemRange(it);

                await _qualityStandardRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Updated", Message = qsItemRangeId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.UpdateItemRange", JsonSerializer.Serialize(entityRange));
                return StatusCode(500,new MessageResponse());            
            }

        }

        [HttpDelete("itemRange/{qsItemRangeId}")] // Post: api/semaphores
        public async Task<ActionResult<bool>> DeleteItemRange( int qsItemRangeId) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var it = _qualityStandardRepository.GetItemRange(qsItemRangeId);

                if (it == null) return BadRequest(new MessageResponse("405","Quality Standard ItemRange not found"));
                

                _qualityStandardRepository.DeleteItemRange(it);

                await _qualityStandardRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Deleted", Message = qsItemRangeId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "QualityStandards.DeleteItemRange", "ItemRangeId:" + qsItemRangeId.ToString());
                return StatusCode(500,new MessageResponse());            
            }

        }        
    }
}