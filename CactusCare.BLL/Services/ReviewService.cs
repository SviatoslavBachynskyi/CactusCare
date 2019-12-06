using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CactusCare.Abstractions;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Services;

namespace CactusCare.BLL.Services
{
    internal class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ReviewDTO>> GetAllAsync()
        {
            return (await _unitOfWork.ReviewRepository.GetAllAsync())
                .Select(d => _mapper.Map<Review, ReviewDTO>(d))
                .ToList();
        }

        public async Task<ReviewDTO> GetAsync(int id)
        {
            return _mapper.Map<Review, ReviewDTO>(await _unitOfWork.ReviewRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(ReviewDTO reviewDto)
        {
            await _unitOfWork.ReviewRepository.InsertAsync(_mapper.Map<ReviewDTO, Review>(reviewDto));
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ReviewDTO reviewDto)
        {
            await _unitOfWork.ReviewRepository.UpdateAsync(_mapper.Map<ReviewDTO, Review>(reviewDto));
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ReviewRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}