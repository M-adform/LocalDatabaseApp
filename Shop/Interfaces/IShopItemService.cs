using Shop.DTOs;

namespace Shop.Interfaces
{
    public interface IShopItemService
    {
        public List<ShopItemInternal> GetAllShopItems();
        public ShopItemInternal GetShopItem(int id);
        public int InsertShopItem(string name, decimal price);
        public ShopItemResponse UpdateShopItem(int id, string name, string price);
        public int DeleteShopItem(int id);
    }
}
