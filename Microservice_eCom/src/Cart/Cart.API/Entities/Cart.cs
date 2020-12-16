using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Entities
{
    public class CartEntity
    {
        public string UserName { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public CartEntity()
        {

        }
        public CartEntity(string userName)
        {
            UserName = userName;
        }

        //calculate cart total

        public decimal Total
        {
            get
            {
                decimal _totalprice = 0;
                foreach (var item in Items)
                {
                    _totalprice += item.Price * item.Quantity;
                }
                return _totalprice;
            }
        }
    }
}
