using AutoMapper;
using Cart.API.Entities;
using Cart.API.Repositories;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Cart.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly EventBusRabbitMQProducer _eventBusRabbitMQProducer;

        public CartController(ICartRepository cartRepository, IMapper mapper, EventBusRabbitMQProducer eventBusRabbitMQProducer)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _eventBusRabbitMQProducer = eventBusRabbitMQProducer;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CartEntity), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CartEntity>> GetCart(string userName)
        {
            var cart = await _cartRepository.GetCart(userName);
            return Ok(cart ?? new CartEntity(userName));

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

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] CartCheckout cartCheckout)
        {
            //Get Total Price of Cart
            //Remove Cart
            //Send Checkout event to rabbitmq

            var cartDetails = await _cartRepository.GetCart(cartCheckout.UserName);

            if (cartDetails == null) { return BadRequest(); }

            // var cartRemove = await _cartRepository.DeleteCart(cartDetails.UserName);
            // if (!cartRemove) { return BadRequest(); }

            var eventMessage = _mapper.Map<CartCheckoutEvent>(cartCheckout);
            eventMessage.RequestId = Guid.NewGuid();
            eventMessage.Total = cartDetails.Total;

            try
            {
                _eventBusRabbitMQProducer.PubishCheckout(EventBusConstants.CartCheckoutQueue, eventMessage);
            }
            catch (Exception)
            {
                throw;
            }

            return Accepted();

        }

    }
}
