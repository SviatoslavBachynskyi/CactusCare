using System;
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
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewDTO>>> GetAll()
        {
            return await _reviewService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> Get(int id)
        {
            return await _reviewService.GetAsync(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ReviewDTO reviewDto)
        {
            try
            {
                await _reviewService.UpdateAsync(reviewDto);
                return StatusCode(200, "OK");
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Review with id {reviewDto.Id} not found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}