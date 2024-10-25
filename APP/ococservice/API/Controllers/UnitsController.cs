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
    public class UnitsController: BaseApiController
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IUserRepositoy _userRepositoy;
        private readonly IMapper _mapper;
        private readonly ILogApi _logApi;

        public UnitsController(IUnitRepository unitRepository, IUserRepositoy userRepositoy
            , IMapper mapper, ILogApi logApi)
        {
            _unitRepository = unitRepository;
            _userRepositoy = userRepositoy;
            _mapper = mapper;
            _logApi = logApi;
        }

        [HttpGet()] // "{isActive}"
        public async Task<ActionResult<IEnumerable<UnitDTO>>> GetUnit() 
        {
            try
            {

                var it = await _unitRepository.GetAllAsync();
                var itR = _mapper.Map<IEnumerable<UnitDTO>>(it);

                return Ok(itR);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Units.GetUnit", "N/A"); //JsonSerializer.Serialize(survey));
                return StatusCode(500, new MessageResponse());  
            } 
        }

    }
}