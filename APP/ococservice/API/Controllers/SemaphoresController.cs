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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Semaphore = API.Entities.Semaphore;

namespace API.Controllers
{
    [Authorize]
    public class SemaphoresController: BaseApiController
    {
        private readonly ISemaphoreRepository _semaphoreRepository;
        private readonly IUserRepositoy _userRepositoy;
        private readonly IMapper _mapper;
        private readonly ILogApi _logApi;

        public SemaphoresController(ISemaphoreRepository semaphoreRepository, IUserRepositoy userRepositoy
            , IMapper mapper, ILogApi logApi)
        {
            _semaphoreRepository = semaphoreRepository;
            _userRepositoy = userRepositoy;
            _mapper = mapper;
            _logApi = logApi;
        }

        [HttpGet()] // "{isActive}"
        public async Task<ActionResult<IEnumerable<SemaphoreDTO>>> GetSemaphores() 
        {
            try
            {

                var it = await _semaphoreRepository.GetAllAsync();
                var itR = _mapper.Map<IEnumerable<SemaphoreDTO>>(it);

                return Ok(itR);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Semaphores.GetSemaphores", "N/A"); //JsonSerializer.Serialize(survey));
                return StatusCode(500, new MessageResponse());  
            } 
        }

        [HttpPost()] // Post: api/semaphores
        public async Task<ActionResult<bool>> Create(SemaphoreIDTO item) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var it = new Semaphore();
                
                _mapper.Map(item, it);

                _semaphoreRepository.Add(it);

                await _semaphoreRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Added", Message = it.SemaphoreId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Semaphores.Create", JsonSerializer.Serialize(item));
                return StatusCode(500,new MessageResponse());            
            }

        }

        [HttpPut("{id}")] // Post: api/semaphores
        public async Task<ActionResult<bool>> Update(SemaphoreIDTO item, int Id) 
        {

            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var it = _semaphoreRepository.GetId(Id);

                if (it == null) return BadRequest(new MessageResponse("405","Semaphore not found"));
                
                _mapper.Map(item, it);

                _semaphoreRepository.Update(it);

                await _semaphoreRepository.SaveAllAsync();

                return Ok(new MessageResponse(){  StateCode = "200", FriendlyMessage ="Updated", Message = it.SemaphoreId.ToString()});
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Semaphores.Update", JsonSerializer.Serialize(item));
                return StatusCode(500,new MessageResponse());            
            }

        }
    }
}