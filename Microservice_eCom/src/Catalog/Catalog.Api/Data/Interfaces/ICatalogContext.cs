﻿using Catalog.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Data.Interfaces
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
