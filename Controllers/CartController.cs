using Microsoft.AspNetCore.Mvc;
using OnlineOrderPlacementSystem.Contracts;
using OnlineOrderPlacementSystem.Model;
using Microsoft.AspNetCore.Http;

namespace OnlineOrderPlacementSystemSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IShoppingCartContract _shoppingCartContract;

        public CartController(
          IShoppingCartContract shoppingCartContract
        )
        {
            _shoppingCartContract = shoppingCartContract;
        }

        [HttpPost]
        public ActionResult CheckOut(ShoppingCart cart)
        {
            var result = _shoppingCartContract.PlaceOrder(cart);
            return Ok();
        }
    }
}
