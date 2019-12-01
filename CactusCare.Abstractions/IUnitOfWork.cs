using CactusCare.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions
{
    public interface IUnitOfWork
    {
        ISpecialityRepository SpecialityRepository { get; }

        void Save();
    }
}
