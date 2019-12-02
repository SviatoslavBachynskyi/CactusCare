using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CactusCare.Abstractions;
using CactusCare.Abstractions.DTOs;
using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Services;

namespace CactusCare.BLL.Services
{
    internal class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ReviewDTO Get(int id)
        {
            var model = _unitOfWork.ReviewRepository.GetById(id);
            return _mapper.Map<Review, ReviewDTO>(model);
        }

        public List<ReviewDTO> GetAll()
        {
            return _unitOfWork.ReviewRepository.GetAll().Select(s => _mapper.Map<Review, ReviewDTO>(s)).ToList();
        }
    }
}