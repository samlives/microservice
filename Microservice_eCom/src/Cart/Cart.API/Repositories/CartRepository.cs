using Cart.API.Data.Interfaces;
using Cart.API.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ICartContext _context;

        public CartRepository(ICartContext context)
        {
            _context = context;
        }

        public async Task<CartEntity> GetCart(string userName)
        {
            var cart = await _context
                 .Redis
                 .StringGetAsync(userName);

            if (cart.IsNullOrEmpty) return null;

            return JsonConvert.DeserializeObject<CartEntity>(cart);
        }

        public async Task<CartEntity> UpdateCart(CartEntity cart)
        {
            var updated = await _context
                         .Redis
                         .StringSetAsync(cart.UserName, JsonConvert.SerializeObject(cart));
            if (!updated) return null;

            return await GetCart(cart.UserName);
        }
        public async Task<bool> DeleteCart(string userName)
        {
            return await _context.Redis.KeyDeleteAsync(userName);
        }

    }
}
