using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Http;
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

        //TODO make other method async
        [HttpGet]
        public async Task<ActionResult<List<SpecialityDTO>>> GetAll()
        {
            return await Task.Run(() => _specialityService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialityDTO>> Get(int id)
        {
            return await Task.Run(() => _specialityService.Get(id));
        }
    }
}