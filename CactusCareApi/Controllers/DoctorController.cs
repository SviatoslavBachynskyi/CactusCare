﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return await _doctorService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDTO>> Get(int id)
        {
            return await _doctorService.GetAsync(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DoctorDTO doctorDto)
        {
            try
            {
                await _doctorService.UpdateAsync(doctorDto);
                return StatusCode(200, "OK");
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Doctor with id {doctorDto.Id} not found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}