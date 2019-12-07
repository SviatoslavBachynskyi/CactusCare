using CactusCare.Abstractions;
using CactusCare.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.BLL.Services
{
    class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
