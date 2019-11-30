using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions.Entities
{
    public interface IEntity<T>
    {
       public T Id { get; set; }
    }
}
