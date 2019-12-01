using CactusCare.Abstractions.Services;
using CactusCare.Abstractions.DTOs;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CactusCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }

        // GET: api/Speciality
        [HttpGet]
        public ActionResult<List<SpecialityDTO>> Get()
        {
            return _specialityService.GetAll();
        }

        // GET: api/Speciality/id
        [HttpGet("{id}")]
        public ActionResult<SpecialityDTO> Get(int id)
        {
            try
            {
                return _specialityService.Get(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}