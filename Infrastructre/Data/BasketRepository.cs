using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructre.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _Database;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _Database = redis.GetDatabase();// here we have got a connection to our database available for us to use
            // so we can do whate ever we need add a basket remove a basket  etc.
        }
        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            //the basket is gonna be stored as string  in redis database 
            // what we are gonna do is take our obj  (json that comes up from the client ) we gonna 
            // serialize that into a string which stored in our redis database   
            // then when we want to get it out we are gonna serialize it back into something we can use
            // deserialize it into customer basket 
            var data = await _Database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
            // if we have data then we are gonna serialize into our customer basket

        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _Database.KeyDeleteAsync(basketId);
        }

      

        public async Task<CustomerBasket> UpdateBasketAsyn(CustomerBasket basket)
        {
            var created = await _Database.StringSetAsync(basket.Id, 
                JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));
            if (!created) return null;

            return await GetBasketAsync(basket.Id);

            // we need to think who many baske we need in memory
            // who much mempry we have in the server

        }
    }
}
