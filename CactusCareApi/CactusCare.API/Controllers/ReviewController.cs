using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CactusCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this._reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewDto>>> GetAll()
        {
            return await this._reviewService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> Get(int id)
        {
            return await this._reviewService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ReviewDto reviewDto)
        {
            try
            {
                await this._reviewService.InsertAsync(reviewDto);
                return StatusCode(200, "OK");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ReviewDto reviewDto)
        {
            try
            {
                await this._reviewService.UpdateAsync(reviewDto);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this._reviewService.DeleteAsync(id);
                return StatusCode(200, "OK");
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Review with id {id} not found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}