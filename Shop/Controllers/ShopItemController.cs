using Microsoft.AspNetCore.Mvc;
using Shop.DTOs;
using Shop.Interfaces;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ShopItemController : ControllerBase
    {
        private readonly IShopItemService _shopItemService;

        public ShopItemController(IShopItemService shopItemService)
        {
            _shopItemService = shopItemService;
        }

        [HttpGet]
        public List<ShopItemInternal> GetAllShopItems()
        {
            return _shopItemService.GetAllShopItems();
        }


        [HttpGet]
        public ShopItemInternal GetShopItem(int id)
        {
            return _shopItemService.GetShopItem(id);
        }

        [HttpPost]
        public async Task<IActionResult> InsertShopItem([FromBody] ShopItemRequest shopItem)
        {
            return Ok(_shopItemService.InsertShopItem(shopItem.Item_Name, shopItem.Price));
        }

        [HttpPut]
        public async Task<ShopItemResponse> UpdateShopItem(int id, string name, string price)
        {
            return _shopItemService.UpdateShopItem(id, name, price);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteShopItem(int id)
        {
            return Ok(_shopItemService.DeleteShopItem(id));
        }
    }
}





