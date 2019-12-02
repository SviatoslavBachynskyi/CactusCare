﻿using System;
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
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HospitalDTO>>> GetAll()
        {
            return await Task.Run(() => _hospitalService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HospitalDTO>> Get(int id)
        {
            return await Task.Run(() => _hospitalService.Get(id));
        }
    }
}