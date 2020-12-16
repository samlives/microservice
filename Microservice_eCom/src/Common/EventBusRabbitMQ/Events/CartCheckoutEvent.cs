using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusRabbitMQ.Events
{
    public class CartCheckoutEvent
    {
        public Guid RequestId { get; set; }
        public string UserName { get; set; }
        public decimal Total { get; set; }

        //Biling Address
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        //Shipping
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingEmailAddress { get; set; }
        public string ShippingAddressLine { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingState { get; set; }
        public string ShippingZipCode { get; set; }

        //Payment
        public string CardName { get; set; }
        public string CardNo { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        public int PaymentMethod { get; set; }
    }
}
