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
    public class CountriesController: BaseApiController
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IUserRepositoy _userRepositoy;
        private readonly IMapper _mapper;
        private readonly ILogApi _logApi;

        public CountriesController(ICountryRepository countryRepository, IUserRepositoy userRepositoy
            , IMapper mapper, ILogApi logApi)
        {
            _countryRepository = countryRepository;
            _userRepositoy = userRepositoy;
            _mapper = mapper;
            _logApi = logApi;
        }
        [HttpGet()] // "{isActive}"
        public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountries() 
        {
            try
            {

                var cou = await _countryRepository.GetAllAsync();
                var couR = _mapper.Map<IEnumerable<CountryDTO>>(cou);

                return Ok(couR);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Countries.GetCountries", "N/A"); //JsonSerializer.Serialize(survey));
                return StatusCode(500, new MessageResponse());  
            } 
        }

        [HttpGet("{id}/states")] 
        public async Task<ActionResult<IEnumerable<StateDTO>>> GetStates(int id) 
        {
            try
            {

                var subc = await _countryRepository.GetStates(id);
                //var catR = _mapper.Map<IEnumerable<SubCategoryDTO>>(cat);

                return Ok(subc);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Countries.GetStates", string.Format("CountryID: {0};", id)); //JsonSerializer.Serialize(survey)); string.Format("P1: {0}; P2: {1}", I1, I2)
                return StatusCode(500, new MessageResponse());  
            } 
        }

        [HttpGet("{stateid}/{subcategoryid}/places")] 
        public async Task<ActionResult<IEnumerable<PlaceDTO>>> GetPlacesByStateCat(int stateId, int subcategoryid) 
        {
            try
            {

                var places = await _countryRepository.GetPlaces(stateId,subcategoryid);
                //var catR = _mapper.Map<IEnumerable<SubCategoryDTO>>(cat);

                return Ok(places);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Countries.GetPlacesByStateCat", string.Format("StateId: {0}; SubCategory: {1};", stateId, subcategoryid)); //JsonSerializer.Serialize(survey)); string.Format("P1: {0}; P2: {1}", I1, I2)
                return StatusCode(500, new MessageResponse());  
            } 
        }
    }
}