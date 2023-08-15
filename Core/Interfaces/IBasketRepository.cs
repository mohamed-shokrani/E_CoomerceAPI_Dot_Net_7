﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string BasketId);
        Task<CustomerBasket> UpdateBasketAsyn(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string BasketId);

    }
}
