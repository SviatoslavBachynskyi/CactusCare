using CactusCare.Abstractions.Entities;
using CactusCare.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CactusCare.DAL.Repositories
{
    internal class HospitalRepository : BaseRepository<Hospital, int>, IHospitalRepository
    {
        public HospitalRepository(CactusCareContext context)
            : base(context)
        {
            
        }    
    }
}
