using Catalog.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {


        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name="Sample Product 1",
                    Description="Sample Product Description",
                    Category="Category1",
                    ImageFile=@"https://i.picsum.photos/id/0/5616/3744.jpg?hmac=3GAAioiQziMGEtLbfrdbcoenXoWAW-zlyEAMkfEdBzQ",
                    Price=4.55
                },
                 new Product()
                {
                    Name="Sample Product 1",
                    Description="Sample Product Description",
                    Category="Category1",
                    ImageFile=@"https://i.picsum.photos/id/0/5616/3744.jpg?hmac=3GAAioiQziMGEtLbfrdbcoenXoWAW-zlyEAMkfEdBzQ",
                    Price=4.55
                },
                  new Product()
                {
                    Name="Sample Product 1",
                    Description="Sample Product Description",
                    Category="Category1",
                    ImageFile=@"https://i.picsum.photos/id/0/5616/3744.jpg?hmac=3GAAioiQziMGEtLbfrdbcoenXoWAW-zlyEAMkfEdBzQ",
                    Price=4.55
                },
                   new Product()
                {
                    Name="Sample Product 1",
                    Description="Sample Product Description",
                    Category="Category1",
                    ImageFile=@"https://i.picsum.photos/id/0/5616/3744.jpg?hmac=3GAAioiQziMGEtLbfrdbcoenXoWAW-zlyEAMkfEdBzQ",
                    Price=4.55
                },
                    new Product()
                {
                    Name="Sample Product 1",
                    Description="Sample Product Description",
                    Category="Category1",
                    ImageFile=@"https://i.picsum.photos/id/0/5616/3744.jpg?hmac=3GAAioiQziMGEtLbfrdbcoenXoWAW-zlyEAMkfEdBzQ",
                    Price=4.55
                }


            };
        }
    }
}
