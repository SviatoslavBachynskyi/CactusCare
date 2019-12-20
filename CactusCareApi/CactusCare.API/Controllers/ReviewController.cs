using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Services;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
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

        [Authorize(Roles = "Admin, Reviewer")]
        [HttpPost]
        public async Task<IActionResult> Insert(ReviewDto reviewDto)
        {
                await this._reviewService.InsertAsync(reviewDto);
                return Ok();
        }

        [Authorize(Roles = "Admin, Reviewer")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ReviewDto reviewDto)
        {
            try
            {
                await this._reviewService.UpdateAsync(reviewDto);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(404, $"Review with id {reviewDto.Id} not found");
            }
        }

        //TODO split it for admin and reviewer, so reviewer can only delete his reviews
        [Authorize(Roles = "Admin, Reviewer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await this._reviewService.DeleteAsync(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, $"Review with id {id} not found");
            }
        }
    }
}