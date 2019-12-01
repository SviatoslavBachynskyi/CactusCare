using CactusCare.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions
{
    public interface IUnitOfWork
    {
        public ISpecialityRepository SpecialityRepository { get; }

        public void Save();
    }
}
