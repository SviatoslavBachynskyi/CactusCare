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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoctorDTO>>> GetAll()
        {
            return await Task.Run(() => _doctorService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDTO>> Get(int id)
        {
            return await Task.Run(() => _doctorService.Get(id));
        }
    }
}