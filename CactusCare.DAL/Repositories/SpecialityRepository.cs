using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CactusCare.DAL.Repositories
{
    internal class SpecialityRepository : BaseRepository<Speciality, int>, ISpecialityRepository
    {
        public SpecialityRepository(CactusCareContext context)
            : base(context)
        {
        }
    }
}
