using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _Basket;

        public BasketController(IBasketRepository basket)
        {
          _Basket = basket;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketByIdAsync(string id)
        {
            var basket =await _Basket.GetBasketAsync(id);
   
         
            return Ok(basket ?? new CustomerBasket(id));
        }



        [HttpPost]

        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var updated = await _Basket.UpdateBasketAsyn(basket);
            return Ok(updated);
        }
        [HttpDelete]
        public async Task DeteleBasketAsync(string id)
        {
            await _Basket.DeleteBasketAsync(id);

        }




    }
}
