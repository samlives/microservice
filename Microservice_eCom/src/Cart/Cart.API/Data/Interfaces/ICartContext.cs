using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cart.API.Data.Interfaces
{
    public interface ICartContext
    {
        IDatabase Redis { get; }
    }
}
