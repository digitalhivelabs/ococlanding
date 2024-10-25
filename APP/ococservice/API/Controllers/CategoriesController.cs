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
using SQLitePCL;

namespace API.Controllers
{
    [Authorize]
    public class CategoriesController: BaseApiController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepositoy _userRepositoy;
        private readonly IMapper _mapper;
        private readonly ILogApi _logApi;

        public CategoriesController(ICategoryRepository categoryRepository, IUserRepositoy userRepositoy
            , IMapper mapper, ILogApi logApi)
        {
            _categoryRepository = categoryRepository;
            _userRepositoy = userRepositoy;
            _mapper = mapper;
            _logApi = logApi;
        }

        [HttpGet()] // "{isActive}"
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories() 
        {
            try
            {

                var cat = await _categoryRepository.GetAllAsync();
                var catR = _mapper.Map<IEnumerable<CategoryDTO>>(cat);

                return Ok(catR);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Categories.GetCategories", "N/A"); //JsonSerializer.Serialize(survey));
                return StatusCode(500, new MessageResponse());  
            } 
        }

        [HttpGet("{id}/{lat}/{lon}/{UMed}/places")] // UMed= Km o Mi
        public async Task<ActionResult<IEnumerable<SubCategoryODTO>>> GetPlacesByLatLon(int id, float lat, float lon, string umed) 
        {
            try
            {

                var subc = await _categoryRepository.GetPlacesLatLon(id, lat, lon, umed);
                //var catR = _mapper.Map<IEnumerable<SubCategoryDTO>>(cat);

                return Ok(subc);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Categories.GetPlacesByLatLon", string.Format("CategoryID: {0}; Lat: {1}; Lon: {2}; UMed: {3}", id, lat, lon, umed)); //JsonSerializer.Serialize(survey));
                return StatusCode(500, new MessageResponse());  
            }
        }

        [HttpGet("{id}/{stateId}/{UMed}/places")] // UMed= Km o Mi
        public async Task<ActionResult<IEnumerable<SubCategoryODTO>>> GetPlacesByState(int id, int stateId, string umed) 
        {
            try
            {

                var subc = await _categoryRepository.GetPlaces(id, stateId, umed);
                //var catR = _mapper.Map<IEnumerable<SubCategoryDTO>>(cat);

                return Ok(subc);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Categories.GetPlacesByState", string.Format("CategoryID: {0}; StateId: {1}; UMed: {2}", id, stateId, umed)); //JsonSerializer.Serialize(survey)); string.Format("P1: {0}; P2: {1}", I1, I2)
                return StatusCode(500, new MessageResponse());  
            } 
        }

        [HttpGet("{id}/subcategories")] 
        public async Task<ActionResult<IEnumerable<SubCategoryDTO>>> GetSubCategories(int id) 
        {
            try
            {

                var subc = await _categoryRepository.GetSubCategory(id);
                //var catR = _mapper.Map<IEnumerable<SubCategoryDTO>>(cat);

                return Ok(subc);
            
            } catch(Exception e) {
                _logApi.Record(e.Message, e.StackTrace, "Categories.GetSubCategories", string.Format("CategoryID: {0};", id)); //JsonSerializer.Serialize(survey)); string.Format("P1: {0}; P2: {1}", I1, I2)
                return StatusCode(500, new MessageResponse());  
            } 
        }
    }
}