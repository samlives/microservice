using Cart.API.Entities;
using Cart.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Cart.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        [HttpGet]
        [ProducesResponseType(typeof(CartEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CartEntity>> GetCart(string userName)
        {
            var cart = await _cartRepository.GetCart(userName);
            return Ok(cart?? new CartEntity(userName));

        }

        [HttpPost]
        [ProducesResponseType(typeof(CartEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CartEntity>> UpdateCart([FromBody] CartEntity cartEntity)
        {
            var cart = await _cartRepository.UpdateCart(cartEntity);
            return Ok(cart);
        }

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(CartEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCart(string userName)
        {

            return Ok(await _cartRepository.DeleteCart(userName));

        }

    }
}
