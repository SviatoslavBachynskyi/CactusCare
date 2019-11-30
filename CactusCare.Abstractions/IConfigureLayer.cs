﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CactusCare.Abstractions
{
    public interface IConfigureLayer
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
