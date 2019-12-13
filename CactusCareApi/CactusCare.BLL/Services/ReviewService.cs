using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CactusCare.Abstractions;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Services;
using CactusCare.BLL.Converters;

namespace CactusCare.BLL.Services
{
    internal class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<List<ReviewDTO>> GetAllAsync()
        {
            return (await _unitOfWork.ReviewRepository.GetAllAsync())
                .Select(d => _mapper.Map<Review, ReviewDTO>(d))
                .ToList();
        }

        public async Task<ReviewDTO> GetAsync(int id)
        {
            return _mapper.Map<Review, ReviewDTO>(await this._unitOfWork.ReviewRepository.GetByIdAsync(id));
        }

        public async Task InsertAsync(ReviewDTO reviewDto)
        {
            var review = this._mapper.Map<ReviewDTO, Review>(reviewDto);
            var doctor = await this._unitOfWork.DoctorRepository.GetByIdAsync(review.DoctorId);
            var reviews = (await this._unitOfWork.ReviewRepository.GetAllAsync(r => r.DoctorId.Equals(review.DoctorId)))
                .ToList();
            reviews.Add(review);
            doctor.Rating =
                await Task.Run(() => reviews.Average(r => RatingConverter.ConvertToFiveStarScale(r.Rating)));

            await this._unitOfWork.ReviewRepository.InsertAsync(review);
            await this._unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ReviewDTO reviewDto)
        {
            var review = this._mapper.Map<ReviewDTO, Review>(reviewDto);
            var doctor = await this._unitOfWork.DoctorRepository.GetByIdAsync(review.DoctorId);
            var reviews = (await this._unitOfWork.ReviewRepository.GetAllAsync(r => r.DoctorId.Equals(review.DoctorId)))
                .ToList();
            reviews[reviews.FindIndex(r => r.Id.Equals(review.Id))] = review;
            doctor.Rating =
                await Task.Run(() => reviews.Average(r => RatingConverter.ConvertToFiveStarScale(r.Rating)));

            await this._unitOfWork.ReviewRepository.UpdateAsync(review);
            await this._unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this._unitOfWork.ReviewRepository.DeleteAsync(id);
            await this._unitOfWork.SaveAsync();
        }
    }
}