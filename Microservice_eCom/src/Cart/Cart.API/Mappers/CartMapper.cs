using AutoMapper;
using Cart.API.Entities;
using EventBusRabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Mappers
{
    public class CartMapper : Profile
    {
        public CartMapper()
        {
            CreateMap<CartCheckout, CartCheckoutEvent>().ReverseMap();
        }

    }
}
