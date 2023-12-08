using Shop.DTOs;
using Shop.Interfaces;

namespace Shop.Services
{
    public class ShopItemService : IShopItemService
    {
        private readonly IShopItemRepository _shopItemRepository;

        public ShopItemService(IShopItemRepository shopItemRepository)
        {
            _shopItemRepository = shopItemRepository;
        }

        public List<ShopItemInternal> GetAllShopItems()
        {
            return _shopItemRepository.GetAllShopItems();
        }


        public ShopItemInternal GetShopItem(int id)
        {
            var response = _shopItemRepository.GetShopItem(id);

            if (response == null)
            {
                return null;
            }

            return response;
        }

        public int InsertShopItem(string name, decimal price)
        {
            return _shopItemRepository.InsertShopItem(name, price);
        }

        public ShopItemResponse UpdateShopItem(int id, string name, string price)
        {
            return _shopItemRepository.UpdateShopItem(id, name, price);
        }

        public int DeleteShopItem(int id)
        {
            return _shopItemRepository.DeleteShopItem(id);
        }
    }
}
