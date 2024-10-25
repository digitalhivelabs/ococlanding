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
    public class PointsController: BaseApiController
    {
        private readonly IPointRepository _pointRepository;
        private readonly IUserRepositoy _userRepositoy;
        private readonly IMapper _mapper;
        private readonly ILogApi _logApi;

        public PointsController(IPointRepository pointRepository, IUserRepositoy userRepositoy
            , IMapper mapper, ILogApi logApi)
        {
            _pointRepository = pointRepository;
            _userRepositoy = userRepositoy;
            _mapper = mapper;
            _logApi = logApi;
        }

        [HttpGet("{placeid}")] // UMed= Km o Mi
        public async Task<ActionResult<IEnumerable<PointDTO>>> GetPlacesByPlace(int placeId) 
        {
            try
            {

                var points = await _pointRepository.GetPointByPlace(placeId);
                //var catR = _mapper.Map<IEnumerable<SubCategoryDTO>>(cat);

                return Ok(points);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Points.GetPlacesByPlace", string.Format("PlaceId: {0};", placeId)); //JsonSerializer.Serialize(survey)); string.Format("P1: {0}; P2: {1}", I1, I2)
                return StatusCode(500, new MessageResponse());  
            } 
        }
    }
}