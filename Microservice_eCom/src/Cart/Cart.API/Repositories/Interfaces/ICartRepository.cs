using Cart.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Repositories
{
    public interface ICartRepository
    {
        Task<CartEntity> GetCart(string userName);
        Task<CartEntity> UpdateCart(CartEntity cart);
        Task<bool> DeleteCart(string userName);

    }
}
