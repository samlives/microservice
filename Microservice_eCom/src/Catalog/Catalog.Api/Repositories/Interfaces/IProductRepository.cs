﻿using Catalog.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(string id);
        Task<IEnumerable<Product>> GetProductsByName(string name);
        Task<IEnumerable<Product>> GetProductsByCategory(string CategoryName);


        Task Create(Product product);

        Task<bool> Update(Product product);
        Task<bool> Delete(string id);

    }
}
